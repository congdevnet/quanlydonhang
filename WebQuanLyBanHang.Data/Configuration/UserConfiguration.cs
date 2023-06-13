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
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.Property(x => x.FullName).IsRequired().HasMaxLength(256);

            builder.Property(x => x.Address).IsRequired().HasMaxLength(256);
            builder.Property(x => x.Skype).HasMaxLength(500);
            builder.Property(x => x.Avartar).HasMaxLength(256);
        }
    }
}
