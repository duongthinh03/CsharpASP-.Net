using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class bantin : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);

            rpBanTin.DataSource = dt.BanTin_SelectID(Convert.ToInt32(Request["IDBanTin"]));
            rpBanTin.DataBind();
            rpChiTiet.DataSource = dt.ChiTiet_SelectBanTin(Convert.ToInt32(Request["IDBanTin"]));
            rpChiTiet.DataBind();
        }
    }
}