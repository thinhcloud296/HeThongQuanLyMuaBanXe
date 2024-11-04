using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class NhaCungCap
    {
        [Key]
        public int MaNhaCungCap {  get; set; }
        [Required]
        public string TenNhaCungCap { get; set; }
        [Required]
        public string DiaChiNhaCungCap { get; set; }
        [Required]
        public string SoDienThoaiNhaCungCap { get; set; }
        public string EmailNhaCungCap { get; set; }
    }
}