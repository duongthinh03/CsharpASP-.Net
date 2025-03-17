using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using website_tin_tuc;
namespace website_tin_tuc
{
	public partial class Home : System.Web.UI.MasterPage
	{

        protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
                string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
                BlogDataContext dt = new BlogDataContext(connStr);
                rpBanTin.DataSource = dt.BanTin_SelectAll();
                rpBanTin.DataBind();
            }
		}
	}
}