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
    public class CustomerStatusConfiguration:IEntityTypeConfiguration<CustomerStatus>
    {
        public void Configure(EntityTypeBuilder<CustomerStatus> builder)
        {
            builder.ToTable("CustomerStatus");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();

        }
    }
}
