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
                lblThongBao.Text = "B\u1ea1n c\u1ea7n nh\u1eadp t\u00ean danh m\u1ee5c.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            if (dt.BanTins.Any(x => x.tenBanTin == tenBanTin))
            {
                lblThongBao.Text = "Danh m\u1ee5c n\u00e0y \u0111\u00e3 t\u1ed3n t\u1ea1i.";
                return;
            }

            dt.BanTin_Insert(tenBanTin);
            txtTenBanTin.Text = "";
            lblThongBao.Text = "\u0110\u00e3 th\u00eam danh m\u1ee5c.";
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
                    lblThongBao.Text = "T\u00ean danh m\u1ee5c kh\u00f4ng \u0111\u01b0\u1ee3c b\u1ecf tr\u1ed1ng.";
                    return;
                }

                bool exists = dt.BanTins.Any(x => x.IDBanTin == id);
                if (!exists)
                {
                    lblThongBao.Text = "Kh\u00f4ng t\u00ecm th\u1ea5y danh m\u1ee5c.";
                    return;
                }

                dt.BanTin_Update(tenBanTin, id);
                lblThongBao.Text = "\u0110\u00e3 c\u1eadp nh\u1eadt danh m\u1ee5c.";
            }
            else if (e.CommandName == "DeleteCategory")
            {
                bool hasPosts = dt.ChiTiets.Any(x => x.IDBanTin == id);
                if (hasPosts)
                {
                    lblThongBao.Text = "Kh\u00f4ng th\u1ec3 x\u00f3a danh m\u1ee5c \u0111ang c\u00f3 b\u00e0i vi\u1ebft.";
                    return;
                }

                bool exists = dt.BanTins.Any(x => x.IDBanTin == id);
                if (!exists)
                {
                    lblThongBao.Text = "Kh\u00f4ng t\u00ecm th\u1ea5y danh m\u1ee5c.";
                    return;
                }

                dt.BanTin_Delete(id);
                lblThongBao.Text = "\u0110\u00e3 x\u00f3a danh m\u1ee5c.";
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
    }
}
