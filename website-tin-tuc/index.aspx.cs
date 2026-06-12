using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class index : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
		{
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);
			rpChiTiet.DataSource = dt.ChiTiet_SelectHome();
			rpChiTiet.DataBind();

        }

        protected string GetExcerpt(object content)
        {
            string text = Convert.ToString(content);
            text = Regex.Replace(text, "<.*?>", "");
            text = HttpUtility.HtmlDecode(text).Trim();
            if (text.Length > 150)
            {
                return text.Substring(0, 150) + "...";
            }

            return text;
        }
	}
}
