﻿using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DepartmentMap : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");

            builder.Property(I => I.IsDeleted).HasDefaultValue(false);

            builder.HasOne(s => s.Company)
                   .WithMany(s => s.Departments)
                   .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(I => I.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }

    }
}
