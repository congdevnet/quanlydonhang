using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Data.Configuration
{
    public class GroupCustomerConfiguration : IEntityTypeConfiguration<GroupCustomer>
    {
        public void Configure(EntityTypeBuilder<GroupCustomer> builder)
        {
            builder.ToTable("GroupCustomers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);

        }
    }
}
