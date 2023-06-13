using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Data.Entity
{
    public class Prepayment
    {
        public int Id { get; set; }
        public int PaymentsId { get; set; }
        public double AmountOfMoney { get; set; } // Số tiền 
        public string Note { get; set; }= string.Empty;

        public Payments Payments { get; set; }
    }
}
