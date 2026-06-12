using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class dangky : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string userName = txtUserName.Text.Trim();
            string passWord = txtPassWord.Text.Trim();

            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            if (userName == "" || passWord == "") 
			{
                lblThongBao.Text = "Bạn không được bỏ trống tên truy cập và mật khẩu. Mời bạn nhập lại!";
                txtUserName.Text = "";
                txtPassWord.Text = "";
                txtUserName.Focus();
            }
            else if (userName.Length < 3)
            {
                lblThongBao.Text = "Tên đăng nhập phải có ít nhất 3 ký tự.";
                txtUserName.Focus();
            }
            else if (passWord.Length < 6)
            {
                lblThongBao.Text = "Mật khẩu phải có ít nhất 6 ký tự.";
                txtPassWord.Text = "";
                txtPassWord.Focus();
            }
            else if (dt.DangNhaps.Any(x => x.userName == userName))
            {
                lblThongBao.Text = "Tên đăng nhập đã tồn tại. Mời bạn chọn tên khác!";
                txtPassWord.Text = "";
                txtUserName.Focus();
            }
            else
            {
                dt.DangNhap_Insert(userName, SiteSecurity.HashPassword(passWord));
                Response.Redirect("index.aspx");
            }    

        }
    }
}
