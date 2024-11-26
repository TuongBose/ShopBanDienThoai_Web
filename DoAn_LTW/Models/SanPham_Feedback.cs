using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_LTW.Models
{
    public class SanPham_Feedback
    {
        public List<Models.Feedback> Feedbacks { get; set; }
        public Models.SanPham SanPham { get; set; }
    }
}