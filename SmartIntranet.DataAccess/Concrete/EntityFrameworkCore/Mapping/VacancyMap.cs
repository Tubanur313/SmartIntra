using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class VacancyMap : IEntityTypeConfiguration<Vacancy>
    {
       
        public void Configure(EntityTypeBuilder<Vacancy> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I=>I.Id).UseIdentityColumn();
            builder.Property(I=>I.Title).HasMaxLength(500).IsRequired();
            builder.Property(I=>I.ImagePath).HasMaxLength(300);
            builder.Property(I=>I.PosDesc).HasColumnType("ntext").IsRequired();
            builder.Property(I=>I.CandidateDesc).HasColumnType("ntext").IsRequired();
            builder.Property(I=>I.Salary).HasMaxLength(100).IsRequired();
            builder.Property(I=>I.Occupations).HasMaxLength(100).IsRequired();
            builder.Property(I=>I.StartDate).HasDefaultValue(DateTime.Now); ;
            builder.Property(I=>I.EndDate).HasDefaultValue(null);
            builder.Property(I=>I.City).HasMaxLength(100);
            builder.Property(I=>I.Address).HasMaxLength(200);
            builder.Property(I=>I.Email).HasMaxLength(100);
            builder.Property(I => I.CreatedDate).HasDefaultValue(null);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
            builder.HasOne(s => s.Company)
                   .WithMany(s => s.Vacancies)
                   .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);
            builder.Property(I => I.IsDeleted).HasDefaultValue(false);

        }
    }
}
