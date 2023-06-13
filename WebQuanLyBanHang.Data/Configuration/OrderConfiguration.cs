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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(x => x.Id);

            //builder.HasOne(x => x.OrderInfoContent).WithMany(x => x.Orders).HasForeignKey(x => x.OrInCont);
            //builder.HasOne(x => x.OrderSource).WithMany(x => x.Orders).HasForeignKey(x => x.OrdSocreId);
            //builder.HasOne(x => x.OrderStatus).WithMany(x => x.Order).HasForeignKey(x => x.OrdStaId);
            //builder.HasOne(x => x.MethodDelivery).WithMany(x => x.Order).HasForeignKey(x => x.MetdDelId);
            //builder.HasOne(x => x.SingleType).WithMany(x => x.Order).HasForeignKey(x => x.SinTpeId);
            //builder.HasOne(x => x.User).WithMany(x => x.Order)
               // .HasForeignKey(x => new { x.UserCreId });

        }
    }
}
