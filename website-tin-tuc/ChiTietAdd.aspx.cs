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
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
            dt.ChiTiet_Insert(txtTieuDe.Text, txtNoiDung.Text, DateTime.Now, Convert.ToInt32(drBanTin.SelectedValue));
            Response.Redirect("index.aspx");
        }
    }
}