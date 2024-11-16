using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;
namespace DoAn_LTW.Controllers
{
    public class DienThoaiController : Controller
    {
        // GET: DienThoai
        QLDTDataContext db = new QLDTDataContext();
        public ActionResult TatCaSanPham() //hien thi toan bo san pham
        {
            var danhSachSanPham = db.SanPhams.ToList();
            return View(danhSachSanPham);
        }
        
        public ActionResult XemChiTiet(int msp)
        {
            SanPham sanpham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == msp);
            return View(sanpham);
        }
    }
}