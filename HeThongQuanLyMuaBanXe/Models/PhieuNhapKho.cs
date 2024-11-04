using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HeThongQuanLyMuaBanXe.Models
{
    public class PhieuNhapKho
    {
        [Key]
        public int MaPhieuNhap { get; set; }
        public string MaXe { get; set; }
        public string MaNhaCungCap { get; set; }
        public DateTime? NgayNhap {  get; set; }
        [Required]
        public int SoLuongNhap {  get; set; }
        [Required]
        public decimal GiaNhap {  get; set; }

        public virtual Xe Xe {  get; set; }
        public virtual NhaCungCap NhaCungCap { get; set; }

    }
}