using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class UserCompMap : IEntityTypeConfiguration<UserComp>
    {
        public void Configure(EntityTypeBuilder<UserComp> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.UserId).IsRequired();
            builder.Property(I => I.CompanyId).IsRequired();

            builder.HasOne(s => s.User)
                   .WithMany(s => s.UserComps)
                   .HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(s => s.Company)
                   .WithMany(s => s.UserComps)
                   .HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);
        }
    }
}
