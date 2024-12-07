using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_LTW.Models
{
    public class CartItem
    {
        public int MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public int Gia { get; set; }
        public int SoLuong { get; set; }
        public string HinhAnh { get; set; }

        public int ThanhTien
        {
            get { return Gia * SoLuong; }
        }
    }

}