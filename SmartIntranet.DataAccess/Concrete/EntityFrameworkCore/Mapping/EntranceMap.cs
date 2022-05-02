using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class EntranceMap : IEntityTypeConfiguration<Entrance>
    {
        public void Configure(EntityTypeBuilder<Entrance> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.BrowInfo).HasColumnType("ntext");
            builder.Property(I => I.PcInfo).HasColumnType("ntext");
            builder.Property(I => I.In).HasDefaultValue(null);
            builder.Property(I => I.Out).HasDefaultValue(null);

            builder.HasOne(s => s.IntranetUser)
                   .WithMany(s => s.Entrances)
                   .HasForeignKey(s => s.IntranetUserId).OnDelete(DeleteBehavior.Restrict);

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
