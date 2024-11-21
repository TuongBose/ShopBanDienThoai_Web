using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_LTW.Models
{
    public class SanPham_ThuongHieu
    {
        public List<Models.SanPham> DanhSachSanPham { get; set; }
        public List<Models.ThuongHieu> DanhSachThuongHieu { get; set; }
    }
}