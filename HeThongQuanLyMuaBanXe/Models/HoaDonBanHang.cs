using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class HoaDonBanHang
    {
        [Key]
        public int MaHoaDon {  get; set; }
        public int MaHopDong { get; set; }
        public DateTime? NgayLapHoaDon { get; set; }
        public decimal TongSoTien {  get; set; }
        public decimal ThueVAT {  get; set; }
        public decimal SoTienThanhToan {  get; set; }

        public virtual HopDongMuaBan HopDongMuaBan { get; set; }
    }
}