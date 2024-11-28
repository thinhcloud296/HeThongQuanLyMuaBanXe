using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class NhanVien
    {
        [Key]
        public string MaNhanVien { get; set; }
        [Required]
        public string TenNhanVien { get; set; }
        [Required]
        public string DiaChiNhanVien { get; set; }
        [Required]
        public string SoDienThoaiNhanVien { get; set; }
        [Required]
        public string EmailNhanVien { get; set; }
        [Required]
        public string TenDangNhap { get; set; }
        [Required]
        public string MatKhau { get; set; }
        public string VaiTro { get; set; }

    }
}