using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebQuanLyBanHang.Data.Entity;

namespace WebQuanLyBanHang.Data.Configuration
{
    public class DeliveryAddressConfiguration : IEntityTypeConfiguration<DeliveryAddress>
    {
        public void Configure(EntityTypeBuilder<DeliveryAddress> builder)
        {
            builder.ToTable("DeliveryAddresss");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(256);
            builder.Property(x => x.District).IsRequired();
            builder.Property(x => x.Wards).IsRequired();
            builder.Property(x => x.City).IsRequired();
        }
    }
}
