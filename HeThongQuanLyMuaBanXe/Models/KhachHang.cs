using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class KhachHang
    {
        [Key]
        public int MaKhachHang {  get; set; }
        [Required]
        public string HoTenKhachHang { get; set; }
        [Required]
        public string DiaChiKhachHang { get; set; }
        [Required]
        public string SoDienThoaiKhachHang {  get; set; }
        [Required]
        public string EmailKhachHang {  get; set; }
    }
}