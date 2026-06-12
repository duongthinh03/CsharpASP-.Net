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
                SetMessage("Bạn cần nhập đầy đủ tiêu đề và nội dung.", false);
                return;
            }

            int idBanTin = 0;
            if (!int.TryParse(drBanTin.SelectedValue, out idBanTin))
            {
                SetMessage("Bạn cần tạo danh mục trước khi thêm bài viết.", false);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            dt.ChiTiet_Insert(txtTieuDe.Text.Trim(), txtNoiDung.Text, DateTime.Now, idBanTin);

            txtTieuDe.Text = "";
            txtNoiDung.Text = "";
            SetMessage("Đã thêm bài viết. Bạn có thể nhập tiếp bài mới.", true);
            FocusTitleBox();
        }

        private void FocusTitleBox()
        {
            txtTieuDe.Focus();
            ClientScript.RegisterStartupScript(
                GetType(),
                "focusTitle",
                "window.setTimeout(function(){var el=document.getElementById('" + txtTieuDe.ClientID + "');if(el){el.focus();}},0);",
                true);
        }

        private void SetMessage(string message, bool success)
        {
            lblThongBao.Text = message;
            lblThongBao.CssClass = success ? "form-message success" : "form-message error";
        }
    }
}
