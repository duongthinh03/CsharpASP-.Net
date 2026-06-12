using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class index : System.Web.UI.Page
	{
        private const int PageSize = 5;

        protected void Page_Load(object sender, EventArgs e)
		{
            if (!IsPostBack)
            {
                string keyword = (Request["q"] ?? "").Trim();
                txtSearch.Text = keyword;
                LoadPosts(keyword, GetCurrentPage());
            }

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadPosts(txtSearch.Text, 1);
            FocusSearchBox();
        }

        private void LoadPosts(string keyword, int page)
        {
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            keyword = (keyword ?? "").Trim();

            var query = dt.ChiTiets.AsQueryable();
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                query = query.Where(x => x.TieuDe.Contains(keyword) || x.noiDung.Contains(keyword));
            }

            int totalItems = query.Count();
            int totalPages = Math.Max(1, (int)Math.Ceiling(totalItems / (double)PageSize));
            page = Math.Max(1, Math.Min(page, totalPages));

            rpChiTiet.DataSource = query
                .OrderByDescending(x => x.ngayDang)
                .Skip((page - 1) * PageSize)
                .Take(PageSize)
                .Select(x => new
                {
                    x.ID,
                    x.IDBanTin,
                    x.TieuDe,
                    x.ngayDang,
                    x.lanXem,
                    x.noiDung
                })
                .ToList();

            rpChiTiet.DataBind();
            litPager.Text = BuildPager(page, totalPages, keyword);
        }

        private int GetCurrentPage()
        {
            int page = 1;
            int.TryParse(Request["page"], out page);
            return page < 1 ? 1 : page;
        }

        private string BuildPager(int currentPage, int totalPages, string keyword)
        {
            if (totalPages <= 1)
            {
                return "";
            }

            StringBuilder html = new StringBuilder();
            html.Append("<div class=\"pager\">");
            AppendPagerLink(html, currentPage - 1, "&lsaquo;", currentPage == 1, keyword);

            int start = Math.Max(1, currentPage - 1);
            int end = Math.Min(totalPages, start + 2);
            start = Math.Max(1, end - 2);

            for (int i = start; i <= end; i++)
            {
                AppendPagerLink(html, i, i.ToString(), false, keyword, i == currentPage);
            }

            AppendPagerLink(html, currentPage + 1, "&rsaquo;", currentPage == totalPages, keyword);
            html.Append("</div>");
            return html.ToString();
        }

        private void AppendPagerLink(StringBuilder html, int page, string text, bool disabled, string keyword, bool active = false)
        {
            if (disabled)
            {
                html.AppendFormat("<span class=\"pager-item disabled\">{0}</span>", text);
                return;
            }

            string url = "index.aspx?page=" + page;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                url += "&q=" + HttpUtility.UrlEncode(keyword);
            }

            html.AppendFormat("<a class=\"pager-item{0}\" href=\"{1}\">{2}</a>", active ? " active" : "", url, text);
        }

        private void FocusSearchBox()
        {
            txtSearch.Focus();
            ClientScript.RegisterStartupScript(
                GetType(),
                "focusSearch",
                "window.setTimeout(function(){var el=document.getElementById('" + txtSearch.ClientID + "');if(el){el.focus();el.setSelectionRange(el.value.length,el.value.length);}},0);",
                true);
        }

        protected string GetExcerpt(object content)
        {
            string text = Convert.ToString(content);
            text = Regex.Replace(text, "<.*?>", "");
            text = HttpUtility.HtmlDecode(text).Trim();
            if (text.Length > 150)
            {
                return text.Substring(0, 150) + "...";
            }

            return text;
        }
	}
}
