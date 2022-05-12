using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class IntranetUserMap : IEntityTypeConfiguration<IntranetUser>
    {
        public void Configure(EntityTypeBuilder<IntranetUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            //builder.Property(I => I.FullName).IsRequired();
            builder.Property(I => I.FirstName).IsRequired();
            builder.Property(I => I.LastName).IsRequired();
            builder.Property(I => I.Picture).HasDefaultValue("default.png");
            builder.Property(I => I.IsDeleted);



            builder.HasOne(s => s.Department)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Company)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Position)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.PositionId).OnDelete(DeleteBehavior.Restrict);


            builder.Property(I => I.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }


    }
}
