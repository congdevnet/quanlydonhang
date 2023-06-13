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
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductCode).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.ProductName).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Quanlity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.InitialPrice).IsRequired();
            builder.Property(x => x.Mass).IsRequired();
            builder.Property(x => x.Barcode).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Picture).IsUnicode(false).IsRequired().HasMaxLength(256);

            //builder.HasOne(p => p.Unit)
            //   .WithMany(x => x.Products)
            //   .HasForeignKey(x => x.UnitId);

            //builder.HasOne(p => p.ClassifyProduct)
            //   .WithMany(x => x.Products)
            //   .HasForeignKey(x => x.ClaPro);

            //builder.HasOne(p => p.StatusProduct)
            //   .WithMany(x => x.Products)
            //   .HasForeignKey(x => x.StsPro);
        }
    }
}
