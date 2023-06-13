using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Data.Entity
{
    public class ComboProduct
    {

        public Guid Id { get; set; }
        public string ProductCode { get; set; } = string.Empty;
        public double Quanlity { get; set; }
        public double InventoryNumber { get; set; }
        public string Barcode { get; set; } = string.Empty;
        public string ProductCombo { get; set; } = string.Empty;
        public double Price { get; set; } = double.NaN;
        public double InitialPrice { get; set; } = double.NaN;
        public double Mass { get; set; } = double.NaN;
        public string Picture { get; set; } = string.Empty;
        public DateTime? DateCreated { get; set; }
        /// <summary>
        /// expired Product
        /// </summary>
        public DateTime? Expired { get; set; }
        public int UnitProId { get; set; }
        public int StsProId { get; set; }
        public int ClaProId { get; set; }

        public Unit Unit { get; set; }
        public StatusProduct StatusProduct { get; set; }
        public ClassifyProduct ClassifyProduct { get; set; }
        
     }
}
