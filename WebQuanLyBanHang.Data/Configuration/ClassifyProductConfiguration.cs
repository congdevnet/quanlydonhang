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
    public class ClassifyProductConfiguration : IEntityTypeConfiguration<ClassifyProduct>
    {
        public void Configure(EntityTypeBuilder<ClassifyProduct> builder)
        {
            builder.ToTable("ClassifyProducts");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
        }
    }
}
