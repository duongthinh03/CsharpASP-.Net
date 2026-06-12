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
                lblThongBao.Text = "B\u1ea1n c\u1ea7n nh\u1eadp \u0111\u1ea7y \u0111\u1ee7 ti\u00eau \u0111\u1ec1 v\u00e0 n\u1ed9i dung.";
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

            post.TieuDe = txtTieuDe.Text.Trim();
            post.noiDung = txtNoiDung.Text;
            int idBanTin = 0;
            if (!int.TryParse(drBanTin.SelectedValue, out idBanTin))
            {
                lblThongBao.Text = "B\u1ea1n c\u1ea7n ch\u1ecdn danh m\u1ee5c.";
                return;
            }

            post.IDBanTin = idBanTin;
            dt.SubmitChanges();

            Response.Redirect("AdminPosts.aspx");
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
    }
}
