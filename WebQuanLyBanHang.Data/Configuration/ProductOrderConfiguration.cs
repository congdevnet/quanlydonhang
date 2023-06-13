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
    public class ProductOrderConfiguration : IEntityTypeConfiguration<ProductOrder>
    {
        public void Configure(EntityTypeBuilder<ProductOrder> builder)
        {
            builder.ToTable("ProductOrders");
            builder.HasKey(x => x.Id);

            //builder.HasOne(p => p.Order)
            // .WithMany(x => x.ProductOrders)
            // .HasForeignKey(x => x.OrderId);

            //builder.HasOne(p => p.Product)
            //   .WithMany(x => x.ProductOrders)
            //   .HasForeignKey(x => x.ProId);
        }
    }
}
