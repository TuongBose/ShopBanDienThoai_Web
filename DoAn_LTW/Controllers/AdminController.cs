using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn_LTW.Models;

namespace DoAn_LTW.Controllers
{
    public class AdminController : Controller
    {
        QLDTDataContext db = new QLDTDataContext();

        public ActionResult QuanLySanPham()
        {
            var listSanPham = db.SanPhams.ToList();
            return View(listSanPham);
        }
        //them san pham
        public ActionResult ThemSanPham()
        {
            ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu");
            ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham");
            return View();
        }
        [HttpPost]
        public ActionResult ThemSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.InsertOnSubmit(sanPham);
                db.SubmitChanges();
                return RedirectToAction("QuanLySanPham");
            }

            //neu co loi thi tra ve
            ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
            ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }
        //sua san pham
        public ActionResult SuaSanPham(int id)
        {
            var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == id);
            if (sanPham == null)
                return HttpNotFound();
            //neu co loi thi tra ve
            ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
            ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }
        [HttpPost]
        public ActionResult SuaSanPham(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var existingSanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
                if (existingSanPham != null)
                {
                    existingSanPham.TenSanPham = sanPham.TenSanPham;
                    existingSanPham.MaThuongHieu = sanPham.MaThuongHieu;
                    existingSanPham.MaLoaiSanPham = sanPham.MaLoaiSanPham;
                    existingSanPham.Gia = sanPham.Gia;
                    existingSanPham.MoTa = sanPham.MoTa;
                    db.SubmitChanges();
                }
                return RedirectToAction("QuanLySanPham");
            }

            //neu co loi thi tra ve
            ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
            ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            return View(sanPham);
        }
        //xoa san pham
        public ActionResult XoaSanPham(int id)
        {
            var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == id);
            if (sanPham != null)
            {
                db.SanPhams.DeleteOnSubmit(sanPham);
                db.SubmitChanges();
            }
            return RedirectToAction("QuanLySanPham");
        }
    }
}
