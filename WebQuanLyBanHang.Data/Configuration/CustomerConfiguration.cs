using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(256)
                .IsUnicode(true)
                .HasDefaultValue("No Name");

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(true)
                .HasDefaultValue("No Address");
            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(500)
                .IsUnicode(false)
                .HasDefaultValue("No Email");

            builder.Property(x => x.PhoneNumber)
                .IsRequired()
            .HasMaxLength(12)
                .IsUnicode(false);

        }
    }
}
