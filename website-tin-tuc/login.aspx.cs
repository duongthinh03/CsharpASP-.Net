using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{

	public partial class login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassWord.Text.Trim();

            if (userName == "" || passWord == "")
            {
                lblThongBao.Text = "Bạn chưa nhập tên đăng nhập hoặc mật khẩu.";
                return;
            }

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            DangNhap account = dt.DangNhaps.FirstOrDefault(x => x.userName == userName);
            if (account != null && SiteSecurity.VerifyPassword(account.passWord, passWord))
            {
                string adminUserName = ConfigurationManager.AppSettings["AdminUserName"] ?? "admin";
                bool isAdmin = string.Equals(userName, adminUserName, StringComparison.OrdinalIgnoreCase);

                if (SiteSecurity.NeedsPasswordUpgrade(account.passWord))
                {
                    account.passWord = SiteSecurity.HashPassword(passWord);
                    dt.SubmitChanges();
                }

                Session["userName"] = userName;
                Session["isLoggedIn"] = true;
                Session["admin"] = isAdmin;
                Session["role"] = isAdmin ? "Admin" : "Member";
                Response.Redirect("index.aspx");
            }
            else
            {
                lblThongBao.Text = "Đăng nhập thất bại. Mời bạn nhập lại!";
                txtUserName.Text = "";
                txtPassWord.Text = "";
                txtUserName.Focus();
            }
        }
    }
}
