using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
    public partial class BanTinManage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SiteSecurity.IsAdmin())
            {
                Response.Redirect("login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadCategories();
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            string tenBanTin = txtTenBanTin.Text.Trim();
            if (tenBanTin == "")
            {
                SetMessage("Bạn cần nhập tên danh mục.", false);
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            if (dt.BanTins.Any(x => x.tenBanTin == tenBanTin))
            {
                SetMessage("Danh mục này đã tồn tại.", false);
                return;
            }

            dt.BanTin_Insert(tenBanTin);
            txtTenBanTin.Text = "";
            SetMessage("Đã thêm danh mục.", true);
            LoadCategories();
        }

        protected void rpBanTinManage_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int id = 0;
            if (!int.TryParse(e.CommandArgument.ToString(), out id))
            {
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);

            if (e.CommandName == "UpdateCategory")
            {
                TextBox txtEdit = (TextBox)e.Item.FindControl("txtEditTenBanTin");
                string tenBanTin = txtEdit.Text.Trim();
                if (tenBanTin == "")
                {
                    SetMessage("Tên danh mục không được bỏ trống.", false);
                    return;
                }

                bool exists = dt.BanTins.Any(x => x.IDBanTin == id);
                if (!exists)
                {
                    SetMessage("Không tìm thấy danh mục.", false);
                    return;
                }

                dt.BanTin_Update(tenBanTin, id);
                SetMessage("Đã cập nhật danh mục.", true);
            }
            else if (e.CommandName == "DeleteCategory")
            {
                bool hasPosts = dt.ChiTiets.Any(x => x.IDBanTin == id);
                if (hasPosts)
                {
                    SetMessage("Không thể xóa danh mục đang có bài viết.", false);
                    return;
                }

                bool exists = dt.BanTins.Any(x => x.IDBanTin == id);
                if (!exists)
                {
                    SetMessage("Không tìm thấy danh mục.", false);
                    return;
                }

                dt.BanTin_Delete(id);
                SetMessage("Đã xóa danh mục.", true);
            }

            LoadCategories();
        }

        private void LoadCategories()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            rpBanTinManage.DataSource = dt.BanTins.OrderBy(x => x.tenBanTin).ToList();
            rpBanTinManage.DataBind();
        }

        private void SetMessage(string message, bool success)
        {
            lblThongBao.Text = message;
            lblThongBao.CssClass = success ? "form-message success" : "form-message error";
        }
    }
}
