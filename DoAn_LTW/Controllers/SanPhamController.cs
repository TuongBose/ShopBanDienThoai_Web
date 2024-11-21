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

            var list_dienthoai_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_dienthoai,
                DanhSachThuongHieu = list_thuonghieu
            };

            return View(list_dienthoai_thuonghieu);
        }

        public ActionResult MayTinhBang(int maloaisanpham)
        {
            var list_maytinhbang = db.SanPhams
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

            var list_maytinhbang_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_maytinhbang,
                DanhSachThuongHieu=list_thuonghieu
            };

            return View(list_maytinhbang_thuonghieu);
        }

        public ActionResult Ipad(int maloaisanpham)
        {
            var list_ipad = db.SanPhams
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

            var list_ipad_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ipad,
                DanhSachThuongHieu = list_thuonghieu
            };

            return View(list_ipad_thuonghieu);
        }

        public ActionResult PhuKien(int maloaisanpham)
        {
            var list_phukien = db.SanPhams
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

            var list_phukien_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_phukien,
                DanhSachThuongHieu = list_thuonghieu
            };

            return View(list_phukien_thuonghieu);
        }

        public ActionResult Sim(int maloaisanpham)
        {
            var list_sim_theocao = db.SanPhams
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

            var list_sim_thecao_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_sim_theocao,
                DanhSachThuongHieu = list_thuonghieu
            };

            return View(list_sim_thecao_thuonghieu);
        }

        public ActionResult Laptop(int maloaisanpham)
        {
            var list_laptop = db.SanPhams
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

            var list_laptop_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_laptop,
                DanhSachThuongHieu = list_thuonghieu
            };

            return View(list_laptop_thuonghieu);
        }
    }
}