﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.IntraTicket.TicketTripEnts;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class BusinessTravelMap : IEntityTypeConfiguration<BusinessTravel>
    {
        public void Configure(EntityTypeBuilder<BusinessTravel> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.PlaceId);
            builder.Property(I => I.CauseId).IsRequired();
            builder.Property(I => I.TicketId).IsRequired();
            builder.Property(I => I.Transport).IsRequired(); 
            builder.Property(I => I.Accommodation).IsRequired();
            builder.Property(I => I.StartDate).IsRequired().HasDefaultValue(null);
            builder.Property(I => I.EndDate).IsRequired().HasDefaultValue(null);

            builder.HasOne(s => s.Ticket)
                .WithMany(s => s.BusinessTravels)
                .HasForeignKey(s => s.TicketId).OnDelete(DeleteBehavior.Restrict);

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
