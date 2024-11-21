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

        public ActionResult DienThoai(int maloaisanpham, int? MaThuongHieu)
        {

            var list_ALL_dienthoai = db.SanPhams
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

            List<Models.SanPham> list_sanpham_thuonghieu;
            if (MaThuongHieu.HasValue)
            {
                list_sanpham_thuonghieu = db.SanPhams
                .Where(sp => sp.MaThuongHieu == MaThuongHieu && sp.MaLoaiSanPham == maloaisanpham)
                .ToList();
            }
            else
                list_sanpham_thuonghieu = list_ALL_dienthoai;

            var list_dienthoai_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ALL_dienthoai,
                DanhSachThuongHieu = list_thuonghieu,
                DanhSachSanPham_ThuongHieu = list_sanpham_thuonghieu
            };

            return View(list_dienthoai_thuonghieu);
        }

        public ActionResult MayTinhBang(int maloaisanpham, int? MaThuongHieu)
        {
            var list_ALL_maytinhbang = db.SanPhams
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

            List<Models.SanPham> list_sanpham_thuonghieu;
            if (MaThuongHieu.HasValue)
            {
                list_sanpham_thuonghieu = db.SanPhams
                .Where(sp => sp.MaThuongHieu == MaThuongHieu && sp.MaLoaiSanPham == maloaisanpham)
                .ToList();
            }
            else
                list_sanpham_thuonghieu = list_ALL_maytinhbang;

            var list_maytinhbang_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ALL_maytinhbang,
                DanhSachThuongHieu=list_thuonghieu,
                DanhSachSanPham_ThuongHieu = list_sanpham_thuonghieu
            };

            return View(list_maytinhbang_thuonghieu);
        }

        public ActionResult Ipad(int maloaisanpham, int? MaThuongHieu)
        {
            var list_ALL_ipad = db.SanPhams
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

            List<Models.SanPham> list_sanpham_thuonghieu;
            if (MaThuongHieu.HasValue)
            {
                list_sanpham_thuonghieu = db.SanPhams
                .Where(sp => sp.MaThuongHieu == MaThuongHieu && sp.MaLoaiSanPham == maloaisanpham)
                .ToList();
            }
            else
                list_sanpham_thuonghieu = list_ALL_ipad;

            var list_ipad_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ALL_ipad,
                DanhSachThuongHieu = list_thuonghieu,
                DanhSachSanPham_ThuongHieu = list_sanpham_thuonghieu
            };

            return View(list_ipad_thuonghieu);
        }

        public ActionResult PhuKien(int maloaisanpham, int? MaThuongHieu)
        {
            var list_ALL_phukien = db.SanPhams
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

            List<Models.SanPham> list_sanpham_thuonghieu;
            if (MaThuongHieu.HasValue)
            {
                list_sanpham_thuonghieu = db.SanPhams
                .Where(sp => sp.MaThuongHieu == MaThuongHieu && sp.MaLoaiSanPham == maloaisanpham)
                .ToList();
            }
            else
                list_sanpham_thuonghieu = list_ALL_phukien;

            var list_phukien_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ALL_phukien,
                DanhSachThuongHieu = list_thuonghieu,
                DanhSachSanPham_ThuongHieu = list_sanpham_thuonghieu
            };

            return View(list_phukien_thuonghieu);
        }

        public ActionResult Sim(int maloaisanpham, int? MaThuongHieu)
        {
            var list_ALL_sim_thecao = db.SanPhams
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

            List<Models.SanPham> list_sanpham_thuonghieu;
            if (MaThuongHieu.HasValue)
            {
                list_sanpham_thuonghieu = db.SanPhams
                .Where(sp => sp.MaThuongHieu == MaThuongHieu && sp.MaLoaiSanPham == maloaisanpham)
                .ToList();
            }
            else
                list_sanpham_thuonghieu = list_ALL_sim_thecao;

            var list_sim_thecao_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ALL_sim_thecao,
                DanhSachThuongHieu = list_thuonghieu,
                DanhSachSanPham_ThuongHieu = list_sanpham_thuonghieu
            };

            return View(list_sim_thecao_thuonghieu);
        }

        public ActionResult Laptop(int maloaisanpham, int? MaThuongHieu)
        {
            var list_ALL_laptop = db.SanPhams
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

            List<Models.SanPham> list_sanpham_thuonghieu;
            if (MaThuongHieu.HasValue)
            {
                list_sanpham_thuonghieu = db.SanPhams
                .Where(sp => sp.MaThuongHieu == MaThuongHieu && sp.MaLoaiSanPham == maloaisanpham)
                .ToList();
            }
            else
                list_sanpham_thuonghieu = list_ALL_laptop;

            var list_laptop_thuonghieu = new Models.SanPham_ThuongHieu
            {
                DanhSachSanPham = list_ALL_laptop,
                DanhSachThuongHieu = list_thuonghieu,
                DanhSachSanPham_ThuongHieu = list_sanpham_thuonghieu
            };

            return View(list_laptop_thuonghieu);
        }
    }
}