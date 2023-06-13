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
    public class SingleTypeConfiguration : IEntityTypeConfiguration<SingleType>
    {
        public void Configure(EntityTypeBuilder<SingleType> builder)
        {
            builder.ToTable("SingleTypes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        }
    }
}
