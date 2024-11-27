using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn_LTW.Controllers
{
    public class NguoiDungController : Controller
    {
        // GET: NguoiDung
        Models.QLDTDataContext db = new Models.QLDTDataContext();

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection Data)
        {
            var username = Data["UserName"];
            var pass = Data["Pass"];

            bool hasError = false;

            if (String.IsNullOrEmpty(username))
            {
                ViewData["LoiUserName"] = "Tên đăng nhập không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(pass))
            {
                ViewData["LoiPass"] = "Mật khẩu không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return View();
            else
            {
                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x => x.USERNAME == username && x.PASS == pass);
                if (hasAccount != null)
                {
                    Session["Account"] = hasAccount;
                    return RedirectToAction("TrangChu", "TrangChu");
                }
                else
                    ViewBag.ThongBao = "Sai tên đăng nhập hoặc sai mật khẩu, vui lòng nhập lại";

                return View();
            }
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection Data, Models.ACCOUNT User)
        {
            var username = Data["UserName"];
            var pass = Data["Pass"];
            var email = Data["Email"];
            var fullname = Data["FullName"];

            bool hasError = false;

            if (String.IsNullOrEmpty(username))
            {
                ViewData["LoiUserName"] = "Tên đăng nhập không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(pass))
            {
                ViewData["LoiPass"] = "Mật khẩu không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["LoiEmail"] = "Email không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(fullname))
            {
                ViewData["LoiFullName"] = "Họ Tên không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return View();
            else
            {
                User.USERNAME = username;
                User.PASS = pass;
                User.EMAIL = email;
                User.FULLNAME = fullname;
                User.ROLENAME = false;

                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x => x.USERNAME == User.USERNAME);
                if (hasAccount == null)
                {
                    db.ACCOUNTs.InsertOnSubmit(User);
                    db.SubmitChanges();
                    return RedirectToAction("DangNhap", "NguoiDung");
                }
                else
                    ViewBag.TB = "Đã có tài khoản UserName này";

                return View();
            }
        }

        public ActionResult DangXuat()
        {
            Session["Account"] = null;
            return RedirectToAction("TrangChu", "TrangChu");
        }

        [HttpGet]
        public ActionResult ThongTinTaiKhoan()
        {
            return View();
        }

        [HttpGet]
        public ActionResult SuaThongTinTaiKhoan()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SuaThongTinTaiKhoan(FormCollection Data)
        {
            var username = Data["UserName"];
            var fullname = Data["FullName"];
            var sdt = Data["SDT"];
            var email = Data["Email"];
            var diachi = Data["DiaChi"];
            
            bool hasError = false;

            if (String.IsNullOrEmpty(fullname))
            {
                ViewData["LoiFullName"] = "Họ tên không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(sdt))
            {
                ViewData["LoiSDT"] = "Số điện thoại không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(email))
            {
                ViewData["LoiEmail"] = "Email không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(diachi))
            {
                ViewData["LoiDiaChi"] = "Địa chỉ không được bỏ trống";
                hasError = true;
            }

            if(hasError)
            return View();
            else
            {
                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x => x.USERNAME == username);
                if (hasAccount !=null)
                {
                    hasAccount.FULLNAME=fullname;
                    hasAccount.SODIENTHOAI = sdt;
                    hasAccount.EMAIL = email;
                    hasAccount.DIACHI = diachi;

                    db.SubmitChanges();
                    Session["Account"] = hasAccount;
                    return RedirectToAction("ThongTinTaiKhoan", "NguoiDung");
                }
                else
                    ViewBag.TB = "Lỗi không sửa đổi được thông tin tài khoản";

                return View();
            }
        }

        [HttpGet]
        public ActionResult DoiMatKhau()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DoiMatKhau(FormCollection Data)
        {
            var username = Data["UserName"];
            var newpass = Data["NewPass"];
            var newpassconfirm = Data["NewPassConfirm"];

            bool hasError = false;

            if (String.IsNullOrEmpty(newpass))
            {
                ViewData["LoiNewPass"] = "Mật khẩu mới không được bỏ trống";
                hasError = true;
            }
            if (String.IsNullOrEmpty(newpassconfirm))
            {
                ViewData["LoiNewPassConfirm"] = "Nhập lại mật khẩu mới không được bỏ trống";
                hasError = true;
            }
            if (newpass != newpassconfirm)
            {
                ViewData["LoiNewPassConfirm"] = "Mật khẩu mới và xác nhận mật khẩu mới không khớp";
                hasError = true;
            }

            if (hasError)
                return View();
            else
            {
                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x => x.USERNAME == username);
                if (hasAccount != null)
                {
                    hasAccount.PASS = newpass;

                    db.SubmitChanges();
                    Session["Account"] = hasAccount;
                    return RedirectToAction("ThongTinTaiKhoan", "NguoiDung");
                }
                else
                    ViewBag.TB = "Lỗi không sửa đổi được thông tin tài khoản";

                return View();
            }
        }

        [HttpGet]
        public ActionResult QuenMatKhau() 
        { 
            return View(); 
        }

        [HttpPost]
        public ActionResult QuenMatKhau(FormCollection Data)
        {
            var sdt = Data["SDT"];

            bool hasError = false;

            if(String.IsNullOrEmpty(sdt))
            {
                ViewData["LoiSDT"] = "Số điện thoại không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return View();
            else
            {
                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x => x.SODIENTHOAI == sdt);
                if (hasAccount != null)
                {
                    ViewBag.SDT = sdt;
                    ViewBag.Pass = hasAccount.PASS;
                    ViewBag.TaiKhoan = hasAccount;
                    return View();
                }
                else
                {
                    ViewBag.TaiKhoan = hasAccount;
                    ViewBag.TB = "Không tìm thấy số điện thoại này";
                    return View();
                }
            }
        }
    }
}