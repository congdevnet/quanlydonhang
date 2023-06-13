using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Infrastructure;

namespace WebQuanLyBanHang.Repository.Interface
{
    public interface IPrepaymentRepository: IRepository<Prepayment>
    {
    }
}
