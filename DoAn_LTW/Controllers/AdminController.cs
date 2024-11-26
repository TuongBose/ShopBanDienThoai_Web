﻿using System;
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

        //public ActionResult QuanLySanPham()
        //{
        //    var listSanPham = db.SanPhams.ToList();
        //    return View(listSanPham);
        //}
        ////them san pham
        //public ActionResult ThemSanPham()
        //{
        //    ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu");
        //    ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham");
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult ThemSanPham(SanPham sanPham)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.SanPhams.InsertOnSubmit(sanPham);
        //        db.SubmitChanges();
        //        return RedirectToAction("QuanLySanPham");
        //    }

        //    //neu co loi thi tra ve
        //    ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
        //    ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
        //    return View(sanPham);
        //}
        ////sua san pham
        //public ActionResult SuaSanPham(int id)
        //{
        //    var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == id);
        //    if (sanPham == null)
        //        return HttpNotFound();
        //    //neu co loi thi tra ve
        //    ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
        //    ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
        //    return View(sanPham);
        //}
        //[HttpPost]
        //public ActionResult SuaSanPham(SanPham sanPham)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var existingSanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
        //        if (existingSanPham != null)
        //        {
        //            existingSanPham.TenSanPham = sanPham.TenSanPham;
        //            existingSanPham.MaThuongHieu = sanPham.MaThuongHieu;
        //            existingSanPham.MaLoaiSanPham = sanPham.MaLoaiSanPham;
        //            existingSanPham.Gia = sanPham.Gia;
        //            existingSanPham.MoTa = sanPham.MoTa;
        //            db.SubmitChanges();
        //        }
        //        return RedirectToAction("QuanLySanPham");
        //    }

        //    //neu co loi thi tra ve
        //    ViewBag.ListThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
        //    ViewBag.ListLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
        //    return View(sanPham);
        //}
        ////xoa san pham
        //public ActionResult XoaSanPham(int id)
        //{
        //    var sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == id);
        //    if (sanPham != null)
        //    {
        //        db.SanPhams.DeleteOnSubmit(sanPham);
        //        db.SubmitChanges();
        //    }
        //    return RedirectToAction("QuanLySanPham");
        //}

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

                if (!ChapNhanDinhDangAnh.Contains(DinhDangFileAnh))
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

                if (HinhAnh != null && HinhAnh.ContentLength > 0)
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

        [HttpGet]
        public ActionResult SuaLoaiSanPham(int id)
        {
            var loaisanpham = db.LoaiSanPhams.FirstOrDefault(x => x.MaLoaiSanPham == id);
            if (loaisanpham == null)
                return HttpNotFound();

            return View(loaisanpham);
        }

        [HttpPost]
        public ActionResult SuaLoaiSanPham(FormCollection Data, HttpPostedFileBase HinhAnh)
        {
            var maloaisanpham = Data["MaLoaiSanPham"];
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

                if (!ChapNhanDinhDangAnh.Contains(DinhDangFileAnh))
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
                Models.LoaiSanPham LSP = db.LoaiSanPhams.FirstOrDefault(x => x.MaLoaiSanPham == int.Parse(maloaisanpham));
                if (LSP != null)
                {
                    LSP.TenLoaiSanPham = tenloaisanpham;
                    LSP.TenController = tencontroller;

                    if (HinhAnh != null && HinhAnh.ContentLength > 0)
                    {
                        string fileName = Path.GetFileName(HinhAnh.FileName);
                        string path = Path.Combine(Server.MapPath("~/Images/Icon/"), fileName);

                        HinhAnh.SaveAs(path);
                        LSP.HinhAnh = fileName;
                    }

                    db.SubmitChanges();
                    return RedirectToAction("QuanLyLoaiSanPham", "Admin");
                }
                else
                    ViewBag.TB = "Không có loại sản phẩm này";

                return View();
            }
        }

        public ActionResult XoaLoaiSanPham(int id)
        {
            var LSP = db.LoaiSanPhams.FirstOrDefault(x => x.MaLoaiSanPham == id);
            if (LSP != null)
            {
                TempData["ErrorMessage"] = "Xóa thành công.";
                db.LoaiSanPhams.DeleteOnSubmit(LSP);
                db.SubmitChanges();
            }
            return RedirectToAction("QuanLyLoaiSanPham", "Admin");
        }

        // Hiển thị danh sách sản phẩm
        public ActionResult QuanLySanPham()
        {
            var sanPhams = db.SanPhams.ToList();
            return View(sanPhams);
        }

        // Chi tiết sản phẩm
        public ActionResult Details(int id)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        // Tạo sản phẩm mới - GET

        [HttpGet]
        public ActionResult Create()
        {
            // Danh sách Thương Hiệu
            ViewBag.ThuongHieuList = new SelectList(db.ThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu");

            // Danh sách Loại Sản Phẩm
            ViewBag.LoaiSanPhamList = new SelectList(db.LoaiSanPhams.ToList(), "MaLoaiSanPham", "TenLoaiSanPham");

            return View();
        }

        // Tạo sản phẩm mới - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SanPham sanPham, HttpPostedFileBase uploadHinhAnh)
        {
            var maxId = db.SanPhams.Any() ? db.SanPhams.Max(sp => sp.MaSanPham) : 0;
            sanPham.MaSanPham = maxId + 1; // Gán giá trị tiếp theo

            if (ModelState.IsValid)
            {
                // Kiểm tra nếu người dùng đã chọn ảnh
                if (uploadHinhAnh != null && uploadHinhAnh.ContentLength > 0)
                {
                    // Lấy tên tệp của ảnh đã chọn
                    var fileName = Path.GetFileName(uploadHinhAnh.FileName);

                    // Đường dẫn để lưu ảnh
                    var path = Path.Combine(Server.MapPath("~/Images/HinhAnhSP"), fileName);

                    // Lưu tên ảnh vào CSDL
                    sanPham.HinhAnh = fileName;

                    // Nếu bạn muốn lưu ảnh vào thư mục (có thể bỏ qua nếu chỉ muốn lấy tên)
                    try
                    {
                        uploadHinhAnh.SaveAs(path); // Lưu ảnh vào thư mục
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "Không thể lưu ảnh: " + ex.Message);
                        return View(sanPham);
                    }
                }

                // Lưu sản phẩm vào CSDL
                db.SanPhams.InsertOnSubmit(sanPham);
                db.SubmitChanges();
                return RedirectToAction("QuanLySanPham", "Admin");
            }

            // Nếu có lỗi, load lại danh sách ComboBox
            ViewBag.ThuongHieuList = new SelectList(db.ThuongHieus.ToList(), "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
            ViewBag.LoaiSanPhamList = new SelectList(db.LoaiSanPhams.ToList(), "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);

            return View(sanPham);
        }

        // Sửa sản phẩm - GET
        public ActionResult Edit(int id)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }

            ViewBag.MaLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
            return View(sanPham);
        }

        // Sửa sản phẩm - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SanPham sanPham)
        {
            if (ModelState.IsValid)
            {
                var existingSanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == sanPham.MaSanPham);
                if (existingSanPham != null)
                {
                    existingSanPham.TenSanPham = sanPham.TenSanPham;
                    existingSanPham.Gia = sanPham.Gia;
                    existingSanPham.MaThuongHieu = sanPham.MaThuongHieu;
                    existingSanPham.MoTa = sanPham.MoTa;
                    existingSanPham.HinhAnh = sanPham.HinhAnh;
                    existingSanPham.SoLuongTonKho = sanPham.SoLuongTonKho;
                    existingSanPham.MaLoaiSanPham = sanPham.MaLoaiSanPham;

                    db.SubmitChanges();
                }
                return RedirectToAction("QuanLySanPham", "Admin");
            }

            ViewBag.MaLoaiSanPham = new SelectList(db.LoaiSanPhams, "MaLoaiSanPham", "TenLoaiSanPham", sanPham.MaLoaiSanPham);
            ViewBag.MaThuongHieu = new SelectList(db.ThuongHieus, "MaThuongHieu", "TenThuongHieu", sanPham.MaThuongHieu);
            return View(sanPham);
        }

        // Xóa sản phẩm - GET
        public ActionResult Delete(int id)
        {
            var sanPham = db.SanPhams
                 .FirstOrDefault(sp => sp.MaSanPham == id);

            sanPham.ThuongHieu = db.ThuongHieus.FirstOrDefault(th => th.MaThuongHieu == sanPham.MaThuongHieu);
            sanPham.LoaiSanPham = db.LoaiSanPhams.FirstOrDefault(ls => ls.MaLoaiSanPham == sanPham.MaLoaiSanPham);

            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sanPham = db.SanPhams.FirstOrDefault(sp => sp.MaSanPham == id);
            if (sanPham != null)
            {
                var isReferenced = db.ChiTietDonHangs.Any(ct => ct.MaSanPham == id);
                if (isReferenced)
                {
                    TempData["ErrorMessage"] = "Không thể xóa sản phẩm vì nó đang được sử dụng trong đơn hàng.";
                    return RedirectToAction("QuanLySanPham", "Admin");
                }
                else
                {
                    TempData["ErrorMessage"] = "Xóa thành công.";
                    db.SanPhams.DeleteOnSubmit(sanPham);
                    db.SubmitChanges();
                }
            }
            return RedirectToAction("QuanLySanPham", "Admin");
        }
    }
}
