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
    public class AppointmentScheduleCof : IEntityTypeConfiguration<AppointmentSchedule>
    {
        public void Configure(EntityTypeBuilder<AppointmentSchedule> builder)
        {
            builder.ToTable("AppointmentSchedules");
            builder.HasKey(e => e.Id);
            builder.Property(x => x.Note).HasMaxLength(500);
        }
    }
}
