using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
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
            var sanpham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == msp);

            var list_feedback = (
                from FB in db.feedbacks
                join AC in db.ACCOUNTs on FB.USERID equals AC.USERID
                where FB.MaSanPham == msp
                select new Models.Feedback
                {
                    FeedbackID = FB.FeedbackID,
                    USERID = FB.USERID,
                    NoiDung = FB.NoiDung,
                    SoSao = FB.SoSao,
                    MaSanPham = FB.MaSanPham,
                    FullName = AC.FULLNAME
                })
                .ToList();

            var list_sanpham_feedback = new Models.SanPham_Feedback
            {
                SanPham = sanpham,
                Feedbacks = list_feedback
            };

            return View(list_sanpham_feedback);
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
                DanhSachThuongHieu = list_thuonghieu,
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

        // Giỏ hàng
        private ShoppingCart GetCart()
        {
            ShoppingCart cart = Session["Cart"] as ShoppingCart;
            if (cart == null)
            {
                cart = new ShoppingCart();
                Session["Cart"] = cart;
            }
            return cart;
        }

        // Thêm sản phẩm vào giỏ hàng
        public ActionResult AddToCart(int msp, int soLuong, int thaotac)
        {
            SanPham sanPham = db.SanPhams.SingleOrDefault(sp => sp.MaSanPham == msp);
            if (sanPham != null)
            {
                ShoppingCart cart = GetCart();
                cart.AddToCart(sanPham, soLuong);

                Session["CartItemCount"] = cart.GetTotalItemCount();
            }
            if(thaotac == 0) 
            return RedirectToAction("TrangChu", "TrangChu");
                else
                return RedirectToAction("ViewCart", "SanPham");
        }

        // Xem giỏ hàng
        public ActionResult ViewCart()
        {
            ShoppingCart cart = GetCart();
            return View(cart);
        }

        // Xóa sản phẩm khỏi giỏ hàng
        public ActionResult RemoveFromCart(int msp)
        {
            ShoppingCart cart = GetCart();
            cart.RemoveFromCart(msp);
            return RedirectToAction("ViewCart");
        }

        public ActionResult UpdateCart(int maSanPham, int soLuong)
        {
            ShoppingCart cart = GetCart();

            var item = cart.Items.FirstOrDefault(i => i.MaSanPham == maSanPham);
            if (item != null && soLuong > 0)
            {
                item.SoLuong = soLuong;
            }

            Session["CartItemCount"] = cart.Items.Sum(i => i.SoLuong);

            return RedirectToAction("ViewCart");
        }

        [HttpPost]
        public JsonResult UpdateCartJson(int maSanPham, int soLuong)
        {
            ShoppingCart cart = GetCart();

            var item = cart.Items.FirstOrDefault(i => i.MaSanPham == maSanPham);
            if (item != null && soLuong > 0)
            {
                item.SoLuong = soLuong;
            }
            else if (soLuong == 0 && item != null)
            {
                cart.Items.Remove(item);
            }

            Session["CartItemCount"] = cart.Items.Sum(i => i.SoLuong);

            return Json(new
            {
                success = true,
                totalPrice = cart.GetTotal(),
                itemTotal = item?.ThanhTien,
                cartItemCount = Session["CartItemCount"]
            });
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            ShoppingCart cart = GetCart();
            return View(cart);
        }

        [HttpPost]
        public ActionResult ThemDonHang(FormCollection Data)
        {
            var userid = Data["USERID"];
            var tongtien = Data["TongTien"];
            ShoppingCart cart = GetCart();

            bool hasError = false;

            if (String.IsNullOrEmpty(userid))
            {
                TempData["Message"] = "Tên kkách hàng không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return RedirectToAction("DatHang", "SanPham");
            else
            {
                Models.DonHang NewDH = new Models.DonHang
                {
                    USERID = int.Parse(userid),
                    NgayDatHang = DateTime.Now,
                    TongTien = int.Parse(tongtien)
                };
                db.DonHangs.InsertOnSubmit(NewDH);
                db.SubmitChanges();

                foreach (var item in cart.Items)
                {
                    Models.ChiTietDonHang CTDH = new Models.ChiTietDonHang
                    {
                        MaDonHang = NewDH.MaDonHang,
                        MaSanPham = item.MaSanPham,
                        SoLuong = item.SoLuong,
                        GiaBan = item.Gia
                    };
                    db.ChiTietDonHangs.InsertOnSubmit(CTDH);
                }
                db.SubmitChanges();

                return RedirectToAction("PhuongThucThanhToan", "SanPham");
            }
        }

        public ActionResult XacNhanDatHang()
        {
            Models.ShoppingCart cart = GetCart();
            cart.Clear();
            Session["CartItemCount"] = cart.Items.Sum(i => i.SoLuong);
            return View();
        }

        public ActionResult PhuongThucThanhToan()
        {
            Models.ShoppingCart cart = GetCart();
            return View(cart);
        }

        public ActionResult TimKiem(string query)
        {
            if (string.IsNullOrEmpty(query))
            {
                var allProducts = db.SanPhams.ToList();
                return View(allProducts);
            }
            else
            {
                var searchResults = db.SanPhams
                    .Where(sp => sp.TenSanPham.Contains(query) || sp.MoTa.Contains(query))
                    .ToList();

                return View(searchResults);
            }
        }

        [HttpPost]
        public ActionResult Feedback(FormCollection Data, Models.feedback FB, int masanpham, int userid)
        {
            var sosao = int.Parse(Data["SoSao"]);
            var danhgia = Data["DanhGia"];
            var Userid = userid;
            var Masanpham = masanpham;

            bool hasError = false;

            if (sosao == 0)
            {
                ViewData["LoiSoSao"] = "Số sao không được bỏ trống";
                hasError = true;
            }

            if (hasError)
                return RedirectToAction("XemChiTiet", "SanPham", new { @msp = masanpham });
            else
            {
                FB.USERID = userid;
                FB.NoiDung = danhgia;
                FB.SoSao = sosao;
                FB.MaSanPham = masanpham;

                db.feedbacks.InsertOnSubmit(FB);
                db.SubmitChanges();
                return RedirectToAction("XemChiTiet", "SanPham", new { @msp = masanpham });
            }
        }
    }
}
