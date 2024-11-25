using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.IO;
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

        public ActionResult QuanLyLoaiSanPham()
        {
            return View(db.LoaiSanPhams);
        }

        [HttpGet]
        public ActionResult ThemLoaiSanPham()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ThemLoaiSanPham(FormCollection Data, Models.LoaiSanPham LSP, HttpPostedFileBase HinhAnh)
        {
            var tenloaisanpham = Data["TenLoaiSanPham"];
            var tencontroller = Data["TenController"];

            bool hasError = false;

            if (String.IsNullOrEmpty(tenloaisanpham))
            {
                ViewData["LoiTenLoaiSanPham"] = "Tên loại sản phẩm không được bỏ trống";
                hasError = true;
            }

            if (HinhAnh == null || HinhAnh.ContentLength == 0)
            {
                ViewData["LoiHinhAnh"] = "File hình ảnh không được bỏ trống";
                hasError = true;
            }
            else
            {
                var ChapNhanDinhDangAnh = new[] { ".jpg", ".jpeg", ".png", ".gif" };
                var DinhDangFileAnh = System.IO.Path.GetExtension(HinhAnh.FileName).ToLower();

                if(!ChapNhanDinhDangAnh.Contains(DinhDangFileAnh))
                {
                    ViewData["LoiHinhAnh"] = "Chỉ chấp nhận định dạng file ảnh jpg, jpeg, png, gif";
                    hasError = true;
                }
            }

            if (String.IsNullOrEmpty(tencontroller))
            {
                ViewData["LoiTenController"] = "Tên Controller của loại sản phẩm không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return View();
            else
            {
                LSP.TenLoaiSanPham = tenloaisanpham;
                LSP.TenController = tencontroller;

                if(HinhAnh!= null && HinhAnh.ContentLength > 0 )
                {
                    string fileName = Path.GetFileName(HinhAnh.FileName);
                    string path = Path.Combine(Server.MapPath("~/Images/Icon/"), fileName);

                    HinhAnh.SaveAs(path);
                    LSP.HinhAnh = fileName;
                }

                Models.LoaiSanPham hasLSP = db.LoaiSanPhams.FirstOrDefault(x => x.TenLoaiSanPham == LSP.TenLoaiSanPham);
                if (hasLSP == null)
                {
                    db.LoaiSanPhams.InsertOnSubmit(LSP);
                    db.SubmitChanges();
                    return RedirectToAction("QuanLyLoaiSanPham", "Admin");
                }
                else
                    ViewBag.TB = "Đã có loại sản phẩm này";

                return View();
            }
        }
    }
}
