using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HeThongQuanLyMuaBanXe.Models
{
    public class HopDongMuaBan
    {
        [Key]
        public int MaHopDong { get; set; }
        public int MaKhachHang { get; set; }
        public int MaXe { get; set; }
        [Required]
        public DateTime? NgayLapHopDong { get; set; }
        [Required]
        public string DieuKhoanHopDong { get; set; }
        [Required]
        public decimal TongGiaTriHopDong { get; set; }

        public virtual KhachHang KhachHang { get; set; }
        public virtual Xe Xe { get; set; }
    }
}