using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace website_tin_tuc
{
	public partial class chitiet : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            string connStr = ConfigurationManager.ConnectionStrings["BlogConnectionString"].ConnectionString;
            BlogDataContext dt = new BlogDataContext(connStr);

			int? so = null;
            int id = 0;
            if (!int.TryParse(Request["ID"], out id))
            {
                Response.Redirect("index.aspx");
                return;
            }

            ChiTiet post = dt.ChiTiets.FirstOrDefault(x => x.ID == id);
            if (post == null)
            {
                Response.Redirect("index.aspx");
                return;
            }

            int idbanTin = post.IDBanTin ?? 0;
            dt.ChiTiet_LanXem(id, ref so);
            if (so == null)
            {
                so = 0;
            }
            int gt = Convert.ToInt32(so) + 1;
            dt.ChiTiet_SLX(gt, id);
            post.lanXem = gt;

			rpBanTin.DataSource = dt.BanTin_SelectID(idbanTin);
			rpBanTin.DataBind();

			rpChiTiet.DataSource = new[] { post };
			rpChiTiet.DataBind();

            var randomItems = dt.ChiTiets
                .Where(x => x.IDBanTin == idbanTin && x.ID != id)
                .OrderByDescending(x => x.ngayDang)
                .Take(5)
                .Select(x => new
                {
                    x.ID,
                    x.IDBanTin,
                    x.TieuDe,
                    x.ngayDang,
                    x.lanXem
                })
                .ToList();
            rpRanDom.DataSource = randomItems;
            rpRanDom.DataBind();
        }
    }
}
