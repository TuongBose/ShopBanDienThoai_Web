using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_LTW.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: TrangChu
        Models.QLDTDataContext db =  new Models.QLDTDataContext();

        public ActionResult TrangChu()
        {
            var danhSachSanPham = db.SanPhams.ToList();
            return View(danhSachSanPham);
        }
    }
}