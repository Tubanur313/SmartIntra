
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.Intranet.FAQ;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping.FaqMaps
{
    public class FaqMap : IEntityTypeConfiguration<Faq>
    {
        public void Configure(EntityTypeBuilder<Faq> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Question).IsRequired();
            builder.Property(I => I.Answer).IsRequired();
            builder.Property(I => I.File);
            builder.Property(I => I.FaqCategory).IsRequired().HasDefaultValue(FaqCategory.Info);

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
