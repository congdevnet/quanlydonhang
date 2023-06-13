using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Data.Configuration
{
    internal class ExpenseOrderConfiguration : IEntityTypeConfiguration<ExpenseOrder>
    {
        public void Configure(EntityTypeBuilder<ExpenseOrder> builder)
        {
            builder.ToTable("ExpenseOrders");
            builder.HasKey(x => x.Id);  
        }
    }
}
