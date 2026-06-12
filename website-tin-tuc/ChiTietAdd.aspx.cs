using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class ChiTietAdd : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (!SiteSecurity.IsAdmin())
            {
                Response.Redirect("login.aspx");
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
			if (!IsPostBack)
			{
				drBanTin.DataTextField = "tenBanTin";
				drBanTin.DataValueField = "IDBanTin";
				drBanTin.DataSource = dt.BanTin_SelectAll();
				drBanTin.DataBind();
			}
        }

        protected void btnInsert_Click1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text) || string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                lblThongBao.Text = "Bạn cần nhập đầy đủ tiêu đề và nội dung.";
                return;
            }

            int idBanTin = 0;
            if (!int.TryParse(drBanTin.SelectedValue, out idBanTin))
            {
                lblThongBao.Text = "Bạn cần tạo danh mục trước khi thêm bài viết.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            dt.ChiTiet_Insert(txtTieuDe.Text.Trim(), txtNoiDung.Text, DateTime.Now, idBanTin);
            Response.Redirect("index.aspx");
        }
    }
}
