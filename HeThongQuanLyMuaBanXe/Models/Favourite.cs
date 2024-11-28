using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HeThongQuanLyMuaBanXe.Models
{
    public class Favourite
    {
        [Key]
        public int Id { get; set; }
        public int MaXe { get; set; }
        public int SoLuong { get; set; }
        public virtual Xe Xe { get; set; }
    }
}