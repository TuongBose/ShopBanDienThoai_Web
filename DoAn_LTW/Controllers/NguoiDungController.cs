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
                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x=>x.USERNAME==username && x.PASS==pass);
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
            var username= Data["UserName"];
            var pass = Data["Pass"];
            var email=Data["Email"];
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
            if(String.IsNullOrEmpty(fullname))
            {
                ViewData["LoiFullName"] = "Họ Tên không được bỏ trống";
                hasError = true;    
            }

            if(hasError)
                return View();
            else
            {
                User.USERNAME= username; 
                User.PASS= pass;
                User.EMAIL= email;
                User.FULLNAME= fullname;
                User.ROLENAME = false;

                Models.ACCOUNT hasAccount = db.ACCOUNTs.FirstOrDefault(x=>x.USERNAME==User.USERNAME);
                if (hasAccount == null)
                {
                    db.ACCOUNTs.InsertOnSubmit(User);
                    db.SubmitChanges();
                    return RedirectToAction("DangNhap", "NguoiDung");
                }
                else
                    ViewData["HasAccount"] = "Đã có tài khoản UserName này";

                return View();
            }
        }
    }
}