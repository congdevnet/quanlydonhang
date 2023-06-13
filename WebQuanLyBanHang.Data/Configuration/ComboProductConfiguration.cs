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
    public class ComboProductConfiguration : IEntityTypeConfiguration<ComboProduct>
    {
        public void Configure(EntityTypeBuilder<ComboProduct> builder)
        {
            builder.ToTable("ComboProducts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ProductCode).IsRequired().IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.ProductCombo).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Quanlity).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.InitialPrice).IsRequired();
            builder.Property(x => x.Mass).IsRequired();
            builder.Property(x => x.Barcode).IsUnicode(false).HasMaxLength(100);
            builder.Property(x => x.Picture).IsUnicode(false).IsRequired().HasMaxLength(256);

            //builder.HasOne(p => p.Unit)
            //   .WithMany(x => x.ComboProducts)
            //   .HasForeignKey(x => x.UnitProId);

            //builder.HasOne(p => p.ClassifyProduct)
            //   .WithMany(x => x.ComboProducts)
            //   .HasForeignKey(x => x.ClaProId);

            //builder.HasOne(p => p.StatusProduct)
            //   .WithMany(x => x.ComboProducts)
            //   .HasForeignKey(x => x.StsProId);


        }
    }
}
