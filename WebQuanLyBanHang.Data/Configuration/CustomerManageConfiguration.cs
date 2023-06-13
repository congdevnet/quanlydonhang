using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Data.Configuration
{
    public class CustomerManageConfiguration : IEntityTypeConfiguration<CustomerManage>
    {
        public void Configure(EntityTypeBuilder<CustomerManage> builder)
        {
            builder.ToTable("CustomerManages");
            builder.HasKey(e => e.Id);
        }
    }
}
