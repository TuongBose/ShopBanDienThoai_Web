using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class PhanLoaiSanPhamController : Controller
    {
        QLDTDataContext db = new QLDTDataContext();
        //Hien thi san pham theo loai
        //public ActionResult SanPhamTheoLoai(int loaiSanPham)
        //{
        //    //Lay ds sp theo loai
        //    var sanPham = db.SanPhams.Where(sp => sp.MaLoaiSanPham == loaiSanPham).ToList();
        //    ViewBag.LoaiSanPham = loaiSanPham; 
        //    return View(sanPham);
        //}

        ////Hien thi san pham theo thuong hieu
        //public ActionResult SanPhamTheoThuongHieu(int thuongHieu, int loaiSanPham)
        //{
        //    //Lay ds sp theo thuong hieu
        //    var sanPham = db.SanPhams.Where(sp => sp.MaThuongHieu == thuongHieu && sp.MaLoaiSanPham == loaiSanPham).ToList();
        //    ViewBag.ThuongHieu = thuongHieu;
        //    return View("SanPhamTheoLoai", sanPham);
        //}


        //public ActionResult DanhSachLoaiSanPham()
        //{
        //    var loaiSanPham = db.LoaiSanPhams.ToList();
        //    return PartialView(loaiSanPham);
        //}


        //public ActionResult DanhSachThuongHieu()
        //{
        //    var thuongHieu = db.ThuongHieus.ToList();
        //    return PartialView(thuongHieu);
        //}
        public ActionResult SanPhamTheoLoai(int loaiSanPham, int? thuongHieu)
        {
            // Lấy danh sách sản phẩm theo loại
            var sanPham = db.SanPhams.Where(sp => sp.MaLoaiSanPham == loaiSanPham);

            // Nếu có thương hiệu, lọc thêm theo thương hiệu
            if (thuongHieu.HasValue)
            {
                sanPham = sanPham.Where(sp => sp.MaThuongHieu == thuongHieu);
            }

            // Lấy danh sách thương hiệu để hiển thị trong Sidebar
            var thuongHieus = db.ThuongHieus.ToList();

            // Truyền dữ liệu vào View
            ViewBag.LoaiSanPham = loaiSanPham;
            ViewBag.ThuongHieus = thuongHieus;
            return View(sanPham.ToList());
        }



    }
}
