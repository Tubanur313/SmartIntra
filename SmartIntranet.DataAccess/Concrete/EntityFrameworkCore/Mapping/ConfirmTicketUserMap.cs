﻿using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class ConfirmTicketUserMap : IEntityTypeConfiguration<ConfirmTicketUser>
    {
        public void Configure(EntityTypeBuilder<ConfirmTicketUser> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(s => s.ConfirmTicket).HasDefaultValue(false);

            //Relation's
            builder.HasOne(d => d.Ticket)
                    .WithMany(p => p.ConfirmTicketUsers)
                    .HasForeignKey(d => d.TicketId);
            builder.HasOne(d => d.IntranetUser)
                   .WithMany(p => p.ConfirmTicketUsers)
                   .HasForeignKey(d => d.IntranetUserId);

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
