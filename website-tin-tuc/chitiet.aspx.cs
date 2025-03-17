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
			//int id = Convert.ToInt32(Request["ID"]);
            //int idbanTin = Convert.ToInt32(Request["IDBanTin"]); 
            int idbanTin = 0;
            int id = 0;
            if (Request["ID"] != null && int.TryParse(Request["ID"].ToString(), out id))
            {
                // Thành công, id đã được gán
            }
            else
            {
                Response.Redirect("index.aspx"); // Chuyển hướng nếu ID không hợp lệ
                return;
            }
            if (Request["IDBanTin"] != null && int.TryParse(Request["IDBanTin"].ToString(), out idbanTin))
            {
                // hợp lệ, đã gán vào idbanTin
            }
            else
            {
                idbanTin = 0; // hoặc giá trị mặc định khác tùy bạn
            }

            // Lấy dữ liệu trong sql server:
            dt.ChiTiet_LanXem(id, ref so);
            if (so == null)
            {
                so = 0;
            }
            int gt = Convert.ToInt32(so) + 1;
            // Tăng số lượt xem
            dt.ChiTiet_SLX(gt, id);
			rpBanTin.DataSource = dt.BanTin_SelectID(idbanTin);
			rpBanTin.DataBind();
			rpChiTiet.DataSource = dt.ChiTiet_SelectID(id);
			rpChiTiet.DataBind();
            var randomItems = dt.ChiTiet_SelectRandom(idbanTin).Where(x => x.ID != id).ToList();
            rpRanDom.DataSource = randomItems;
            rpRanDom.DataBind();
        }
    }
}