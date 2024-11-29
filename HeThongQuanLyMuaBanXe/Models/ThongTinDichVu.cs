using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class ThongTinDichVu
    {
        [Key]
        public string MaDichVu { get; set; }
        public string TenDichVu { get; set; }
        public string MoTaDichVu { get; set; }
        public string AnhDichVu { get; set; }
    }
}