using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class TicketMap : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Title).IsRequired();
            builder.Property(I => I.Description).HasColumnType("ntext");
            builder.Property(e => e.CloseDate).HasColumnType("datetime");
            builder.Property(e => e.DeadLineStart).HasColumnType("Date").HasDefaultValue(null);
            builder.Property(e => e.DeadLineEnd).HasColumnType("Date").HasDefaultValue(null);
            builder.Property(I => I.Confirmed).HasDefaultValue(false);
            builder.Property(I => I.StatusType).HasDefaultValue(StatusType.Open);
            builder.Property(I => I.PriorityType).HasDefaultValue(PriorityType.Normal);
            builder.Property(I => I.OpenDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.GrandTotal).HasDefaultValue(null);
            builder.Property(I => I.OrderPath);
            //Relation's
            builder.HasOne(d => d.CategoryTicket)
                    .WithMany(p => p.Ticket)
                    .HasForeignKey(d => d.CategoryTicketId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Employee)
                   .WithMany(p => p.TicketEmployees)
                   .HasForeignKey(d => d.EmployeeId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.Supporter)
                   .WithMany(p => p.TicketSupporters)
                   .HasForeignKey(d => d.SupporterId).OnDelete(DeleteBehavior.Restrict);



            builder.Property(I => I.IsDeleted);

            builder.Property(I => I.CreatedDate).HasDefaultValue(DateTime.Now);
            builder.Property(I => I.DeleteDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateDate).HasDefaultValue(null);
            builder.Property(I => I.UpdateByUserId).HasDefaultValue(null);
            builder.Property(I => I.CreatedByUserId).HasDefaultValue(null);
            builder.Property(I => I.DeleteByUserId).HasDefaultValue(null);
        }

    }
}
