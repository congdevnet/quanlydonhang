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
    public class ManageComBoConfiguration : IEntityTypeConfiguration<ManageComBo>
    {
        public void Configure(EntityTypeBuilder<ManageComBo> builder)
        {
            builder.ToTable("ManageComBos");
            builder.HasKey(x => new {x.ProId,x.ComProId});
            
            //builder.HasOne(x=>x.Product).WithMany(x=>x.ManageComBos)
            //            .HasForeignKey(x=>x.ProId).OnDelete(DeleteBehavior.ClientSetNull);
            //builder.HasOne(x => x.ComboProduct).WithMany(x => x.ManageComBos)
            //            .HasForeignKey(x => x.ComProId).OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
