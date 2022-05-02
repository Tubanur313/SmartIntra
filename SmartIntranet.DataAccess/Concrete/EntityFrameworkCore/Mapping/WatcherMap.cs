using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class WatcherMap : IEntityTypeConfiguration<Watcher>
    {
        public void Configure(EntityTypeBuilder<Watcher> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            //Relation's
            builder.HasOne(d => d.Ticket)
                    .WithMany(p => p.Watchers)
                    .HasForeignKey(d => d.TicketId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.IntranetUser)
                   .WithMany(p => p.Watchers)
                   .HasForeignKey(d => d.IntranetUserId).OnDelete(DeleteBehavior.Restrict);

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
