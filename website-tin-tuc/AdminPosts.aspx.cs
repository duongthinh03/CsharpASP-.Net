using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
    public partial class AdminPosts : Page
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
                LoadPosts();
            }
        }

        protected void rpBaiViet_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "DeletePost")
            {
                int id = 0;
                if (int.TryParse(e.CommandArgument.ToString(), out id))
                {
                    string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
                    BlogDataContext dt = new BlogDataContext(connStr);
                    bool exists = dt.ChiTiets.Any(x => x.ID == id);
                    if (exists)
                    {
                        dt.ChiTiet_Delete(id);
                        lblThongBao.Text = "\u0110\u00e3 x\u00f3a b\u00e0i vi\u1ebft.";
                    }
                    else
                    {
                        lblThongBao.Text = "Kh\u00f4ng t\u00ecm th\u1ea5y b\u00e0i vi\u1ebft.";
                    }
                    LoadPosts();
                }
            }
        }

        private void LoadPosts()
        {
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            var posts = dt.ChiTiets
                .OrderByDescending(x => x.ngayDang)
                .Select(x => new
                {
                    x.ID,
                    x.TieuDe,
                    x.ngayDang,
                    x.lanXem,
                    TenBanTin = x.BanTin != null ? x.BanTin.tenBanTin : ""
                })
                .ToList();

            rpBaiViet.DataSource = posts;
            rpBaiViet.DataBind();
        }
    }
}
