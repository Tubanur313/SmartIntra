using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class IntranetRoleMap : IEntityTypeConfiguration<IntranetRole>
    {
        public void Configure(EntityTypeBuilder<IntranetRole> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.IsDeleted).IsRequired().HasDefaultValue(false);
            builder.Property(I => I.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }


    }
}
