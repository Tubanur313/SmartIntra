using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class DiscussionMap : IEntityTypeConfiguration<Discussion>
    {
        public void Configure(EntityTypeBuilder<Discussion> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(e => e.Content)
                    .IsRequired()
                    .HasColumnType("ntext");

            //Relation's
            builder.HasOne(d => d.Ticket)
                    .WithMany(p => p.Discussions)
                    .HasForeignKey(d => d.TicketId);
            builder.HasOne(d => d.IntranetUser)
                   .WithMany(p => p.Discussions)
                   .HasForeignKey(d => d.IntranetUserId);

            builder.Property(I => I.IsDeleted);

            builder.Property(I => I.CreatedDate).HasDefaultValue(null);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null); 
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }

    }
}
