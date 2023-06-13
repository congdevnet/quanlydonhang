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
    public class PrepaymentConfiguration : IEntityTypeConfiguration<Prepayment>
    {
        public void Configure(EntityTypeBuilder<Prepayment> builder)
        {
            builder.ToTable("Prepayments");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.AmountOfMoney).IsRequired();
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.HasOne(x => x.Payments).WithMany(x => x.Prepayments).HasForeignKey(x => x.PaymentsId);
        }
    }
}
