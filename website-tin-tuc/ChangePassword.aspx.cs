using System;
using System.Configuration;
using System.Linq;
using System.Web.UI;

namespace website_tin_tuc
{
    public partial class ChangePassword : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SiteSecurity.IsLoggedIn())
            {
                Response.Redirect("login.aspx");
                return;
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string oldPassword = txtOldPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();

            if (oldPassword == "" || newPassword == "" || confirmPassword == "")
            {
                lblThongBao.Text = "B\u1ea1n c\u1ea7n nh\u1eadp \u0111\u1ea7y \u0111\u1ee7 th\u00f4ng tin.";
                return;
            }

            if (newPassword.Length < 6)
            {
                lblThongBao.Text = "M\u1eadt kh\u1ea9u m\u1edbi ph\u1ea3i c\u00f3 \u00edt nh\u1ea5t 6 k\u00fd t\u1ef1.";
                return;
            }

            if (newPassword != confirmPassword)
            {
                lblThongBao.Text = "M\u1eadt kh\u1ea9u nh\u1eadp l\u1ea1i kh\u00f4ng kh\u1edbp.";
                return;
            }

            string userName = Convert.ToString(Session["userName"]);
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            DangNhap account = dt.DangNhaps.FirstOrDefault(x => x.userName == userName);

            if (account == null || !SiteSecurity.VerifyPassword(account.passWord, oldPassword))
            {
                lblThongBao.Text = "M\u1eadt kh\u1ea9u hi\u1ec7n t\u1ea1i kh\u00f4ng \u0111\u00fang.";
                return;
            }

            dt.DangNhap_Update(account.IDName, account.userName, SiteSecurity.HashPassword(newPassword));
            lblThongBao.Text = "\u0110\u00e3 \u0111\u1ed5i m\u1eadt kh\u1ea9u th\u00e0nh c\u00f4ng.";
            txtOldPassword.Text = "";
            txtNewPassword.Text = "";
            txtConfirmPassword.Text = "";
        }
    }
}
