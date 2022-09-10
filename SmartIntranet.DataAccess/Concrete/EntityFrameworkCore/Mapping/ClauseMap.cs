using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.IntraHr;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ClauseMap : IEntityTypeConfiguration<Clause>
    {
        public void Configure(EntityTypeBuilder<Clause> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).IsRequired();
           
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
