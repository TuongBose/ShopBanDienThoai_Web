using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_LTW.Models
{
    public class ShoppingCart
    {
        public List<CartItem> Items { get; set; }

        public ShoppingCart()
        {
            Items = new List<CartItem>();
        }

        public void AddToCart(SanPham sanPham, int soLuong)
        {
            var item = Items.FirstOrDefault(i => i.MaSanPham == sanPham.MaSanPham);
            if (item != null)
            {
                item.SoLuong += soLuong;
            }
            else
            {
                Items.Add(new CartItem
                {
                    MaSanPham = sanPham.MaSanPham,
                    TenSanPham = sanPham.TenSanPham,
                    Gia = sanPham.Gia,
                    SoLuong = soLuong,
                    HinhAnh=sanPham.HinhAnh

                });
            }
        }

        public void RemoveFromCart(int maSanPham)
        {
            var item = Items.FirstOrDefault(i => i.MaSanPham == maSanPham);
            if (item != null)
            {
                Items.Remove(item);
            }
        }

        public decimal GetTotal()
        {
            return Items.Sum(item => item.ThanhTien);
        }

        public void Clear()
        {
            Items.Clear();
        }
    }
}
