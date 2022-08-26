using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class WorkCalendarMap : IEntityTypeConfiguration<WorkCalendar>
    {
        public void Configure(EntityTypeBuilder<WorkCalendar> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Number).IsRequired();
            builder.Property(I => I.Month).HasColumnType("ntext");

            builder.Property(I => I.IsDeleted).HasDefaultValue(false);

            builder.HasOne(s => s.WorkGraphic)
                   .WithMany(s => s.WorkCalendars)
                   .HasForeignKey(s => s.WorkGraphicId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(I => I.CreatedDate).HasDefaultValue(null);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }

    }
}
