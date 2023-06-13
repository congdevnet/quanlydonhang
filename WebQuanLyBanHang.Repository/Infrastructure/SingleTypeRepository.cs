using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.EF;
using WebQuanLyBanHang.Data.Entity;
using WebQuanLyBanHang.Repository.Interface;

namespace WebQuanLyBanHang.Repository.Infrastructure
{
    public class SingleTypeRepository: Repository<SingleType>, ISingleTypeRepository
    {
        public SingleTypeRepository(QuanLyBanHangDbContent dbContext) : base(dbContext)
        {
        }
    }
}
