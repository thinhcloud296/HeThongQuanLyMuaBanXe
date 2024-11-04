using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace HeThongQuanLyMuaBanXe.Models
{
    public class Xe
    {

        [Key]
        public int MaXe { get; set; }
        [Required]
        public string TenXe {  get; set; }
        [Required]
        public string HangXe {  get; set; }
        [Required]
        public string DongXe {  get; set; }
        [Required]
        public string SoKhungXe{get; set; }
        [Required]
        public string SoMayXe {  get; set; }
        [Required]
        public string MauSac {  get; set; }
        [Required]
        public int NamSanXuat {  get; set; }
        [DisplayFormat(DataFormatString ="{0:N0}")]
        [Required]
        public decimal GiaBanXe {  get; set; }
        public string HinhAnh {  get; set; }
    }
}