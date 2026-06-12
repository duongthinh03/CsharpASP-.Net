using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class bantin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            int idBanTin = 0;
            if (!int.TryParse(Request["IDBanTin"], out idBanTin))
            {
                Response.Redirect("index.aspx");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);

            rpBanTin.DataSource = dt.BanTin_SelectID(idBanTin);
            rpBanTin.DataBind();
            rpChiTiet.DataSource = dt.ChiTiet_SelectBanTin(idBanTin);
            rpChiTiet.DataBind();
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
