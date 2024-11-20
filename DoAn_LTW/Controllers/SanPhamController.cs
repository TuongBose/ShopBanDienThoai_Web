using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        QLDTDataContext db = new QLDTDataContext();

        public ActionResult XemChiTiet(int msp)
        {
            SanPham sanpham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == msp);
            return View(sanpham);
        }

        public ActionResult DienThoai(int maloaisanpham)
        {
            var list_dienthoai = db.SanPhams
                .Where(sp => sp.MaLoaiSanPham == maloaisanpham)
                .ToList();

            var list_thuonghieu = db.SanPhams
                .Where(sp => sp.MaLoaiSanPham == maloaisanpham)
                .Select(sp => sp.MaThuongHieu)
                .Distinct()
                .Join
                (
                    db.ThuongHieus,
                    mathuonghieu => mathuonghieu,
                    thuonghieu => thuonghieu.MaThuongHieu,
                    (mathuonghieu, thuonghieu) => thuonghieu
                )
                .ToList();

            var list_dienthoai_thuonghieu = new Models.DienThoai_ThuongHieu
            {
                DanhSachSanPham = list_dienthoai,
                DanhSachThuongHieu = list_thuonghieu
            };

            return View(list_dienthoai_thuonghieu);
        }

        public ActionResult DienThoai_ThuongHieu()
        {
            var list_thuonghieu = db.SanPhams
                .Select(sp => sp.MaThuongHieu)
                .Distinct()
                .ToList();
            return View(list_thuonghieu);
        }
    }
}