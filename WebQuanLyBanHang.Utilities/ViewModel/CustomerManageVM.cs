using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebQuanLyBanHang.Utilities.ViewModel
{
    public class CustomerManageVM
    {
        public Guid CusId { get; set; }
        public Guid StaffMKTId { get; set; }
        public Guid StaffSaleId { get; set; }
        public int CustomerStatusId { get; set; }
    }
}
