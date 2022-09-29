using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Entities.Concrete.IntraHr;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ReportEmployeeMap : IEntityTypeConfiguration<ReportEmployee>
    {
        public void Configure(EntityTypeBuilder<ReportEmployee> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn(1000, 1);
            builder.Property(I => I.GeneratedReport).HasColumnType("ntext");
            builder.Property(I => I.ReportDate).IsRequired();
            builder.Property(I => I.FilePath);

            builder.Property(I => I.IsDeleted).HasDefaultValue(false);
            builder.Property(I => I.CreatedDate).HasDefaultValue(null);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }
    }
}
