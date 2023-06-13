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
    public class StatusProductConfiguration : IEntityTypeConfiguration<StatusProduct>
    {
        public void Configure(EntityTypeBuilder<StatusProduct> builder)
        {
            builder.ToTable("StatusProducts");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        }
    }
}
