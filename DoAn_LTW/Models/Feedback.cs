using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoAn_LTW.Models
{
    public class Feedback
    {
        public int FeedbackID { get; set; }
        public int? USERID { get; set; }
        public string NoiDung { get; set; }
        public int SoSao { get; set; }
        public int? MaSanPham { get; set; }
        public string FullName { get; set; }
    }
}