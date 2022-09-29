using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class IntranetUserMap : IEntityTypeConfiguration<IntranetUser>
    {
        public void Configure(EntityTypeBuilder<IntranetUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn(1000,1);
            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.Surname).IsRequired();
            builder.Property(I => I.Picture).HasDefaultValue("default.png");
            builder.Property(I => I.IsDeleted).HasDefaultValue(false);
            builder.Property(I => I.Birthday).HasDefaultValue(null);
            builder.Property(I => I.Address).HasColumnType("ntext").HasDefaultValue(null);
            builder.Property(I => I.PhoneNumber).HasDefaultValue(null);
            builder.Property(I => I.HomePhoneNumber).HasDefaultValue(null);
            builder.Property(I => I.PersonalPhoneNumber).HasDefaultValue(null);
            builder.Property(I => I.IdCardExpireDate).HasDefaultValue(null);
            //builder.Property(I => I.Gender).IsRequired();
            //builder.Property(I => I.VacationDay).IsRequired();
            //builder.Property(I => I.EducationLevel).IsRequired();
            //builder.Property(I => I.IsMainPlace).IsRequired();
            //builder.Property(I => I.IdCardNumber).IsRequired();
            //builder.Property(I => I.IdCardGiveDate).IsRequired();
            //builder.Property(I => I.IdCardGivePlace).IsRequired();
            //builder.Property(I => I.RegisterAdress).IsRequired();


            builder.HasOne(s => s.Department)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.DepartmentId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Company)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Position)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.PositionId).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(s => s.Grade)
                   .WithMany(s => s.IntranetUsers)
                   .HasForeignKey(s => s.GradeId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(I => I.CreatedDate).HasDefaultValue(null);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }


    }
}
