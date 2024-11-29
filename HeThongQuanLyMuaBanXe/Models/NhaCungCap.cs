using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class NhaCungCap
    {
        [Key]
        public string MaNhaCungCap { get; set; }
        public string TenNhaCungCap { get; set; }
        public string DiaChiNhaCungCap { get; set; }
        public string SoDienThoaiNhaCungCap { get; set; }
        public string EmailNhaCungCap { get; set; }
    }
}