using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

namespace website_tin_tuc
{
    public partial class ChiTietEdit : Page
    {
        private int PostId
        {
            get
            {
                int id = 0;
                int.TryParse(Request["id"], out id);
                return id;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SiteSecurity.IsAdmin())
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (PostId <= 0)
            {
                Response.Redirect("AdminPosts.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCategories();
                LoadPost();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTieuDe.Text) || string.IsNullOrWhiteSpace(txtNoiDung.Text))
            {
                SetMessage("Bạn cần nhập đầy đủ tiêu đề và nội dung.", false);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            ChiTiet post = dt.ChiTiets.FirstOrDefault(x => x.ID == PostId);
            if (post == null)
            {
                Response.Redirect("AdminPosts.aspx");
                return;
            }

            int idBanTin = 0;
            if (!int.TryParse(drBanTin.SelectedValue, out idBanTin))
            {
                SetMessage("Bạn cần chọn danh mục.", false);
                return;
            }

            dt.ChiTiet_Update(txtTieuDe.Text.Trim(), txtNoiDung.Text, PostId, idBanTin);

            Response.Redirect("AdminPosts.aspx?msg=updated");
        }

        private void LoadCategories()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            drBanTin.DataTextField = "tenBanTin";
            drBanTin.DataValueField = "IDBanTin";
            drBanTin.DataSource = dt.BanTin_SelectAll();
            drBanTin.DataBind();
        }

        private void LoadPost()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            ChiTiet post = dt.ChiTiets.FirstOrDefault(x => x.ID == PostId);
            if (post == null)
            {
                Response.Redirect("AdminPosts.aspx");
                return;
            }

            txtTieuDe.Text = post.TieuDe;
            txtNoiDung.Text = post.noiDung;
            if (post.IDBanTin.HasValue)
            {
                drBanTin.SelectedValue = post.IDBanTin.Value.ToString();
            }
        }

        private void SetMessage(string message, bool success)
        {
            lblThongBao.Text = message;
            lblThongBao.CssClass = success ? "form-message success" : "form-message error";
        }
    }
}
