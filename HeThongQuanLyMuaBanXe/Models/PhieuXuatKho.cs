using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class PhieuXuatKho
    {
        [Key]
        public int MaPhieuXuat {  get; set; }
        public int MaXe { get; set; }
        public int MaKhachHang { get; set; }
        public string MaNhanVien { get; set; }
        public DateTime? NgayXuat { get; set; }
        [Required]
        public int SoLuongXuat { get; set; }
        public decimal GiaXuat { get; set; }

        public virtual Xe Xe { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}