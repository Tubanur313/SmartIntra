using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class TicketCheckListMap : IEntityTypeConfiguration<TicketCheckList>
    {
        public void Configure(EntityTypeBuilder<TicketCheckList> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Confirm).HasDefaultValue(false);

            //Relation's
            builder.HasOne(d => d.Ticket)
                    .WithMany(p => p.TicketCheckLists)
                    .HasForeignKey(d => d.TicketId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.CheckList)
                   .WithMany(p => p.TicketCheckLists)
                   .HasForeignKey(d => d.CheckListId).OnDelete(DeleteBehavior.Restrict);

            builder.Property(I => I.IsDeleted).HasDefaultValue(false);

            builder.Property(I => I.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);

        }

    }
}
