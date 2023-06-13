using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Data.Entity
{
    /// <summary>
    /// Quản lý sản phẩm trong gói combo 
    /// Nhiều sản phẩm có trong 1 combo
    /// </summary>

    public class ManageComBo
    {
        public Guid ComProId { get; set; }
        public Guid ProId { get; set; }
        public double Quanlity { get; set; }
        public ComboProduct ComboProduct { get; set; }
        public Product Product { get; set; }

    }
}
