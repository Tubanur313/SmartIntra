using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class PermissionMap : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Reason).IsRequired().HasColumnType("ntext");
            builder.Property(I => I.TicketId).IsRequired();
            builder.Property(I => I.PermissionCreateDate).IsRequired().HasDefaultValue(null);
            builder.Property(I => I.StartTime).IsRequired().HasColumnType("time").HasDefaultValue(null);
            builder.Property(I => I.EndTime).IsRequired().HasColumnType("time").HasDefaultValue(null);

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
