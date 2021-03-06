using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryTicketMap : IEntityTypeConfiguration<CategoryTicket>
    {
        public void Configure(EntityTypeBuilder<CategoryTicket> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Name).IsRequired();

            builder.Property(I => I.IsDeleted);
            builder.Property(I => I.TicketType).HasDefaultValue(TicketType.Task);

            builder.Property(I => I.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }


    }
}
