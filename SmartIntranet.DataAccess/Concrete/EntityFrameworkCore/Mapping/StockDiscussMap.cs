using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.Inventary;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class StockDiscussMap
    {
        public void Configure(EntityTypeBuilder<StockDiscuss> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(e => e.Content).IsRequired().HasColumnType("ntext");

            //Relation
            builder.HasOne(s => s.Stock)
                   .WithMany(s => s.StockDiscusses)
                   .HasForeignKey(s => s.StockId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.IntranetUser)
                   .WithMany(p => p.StockDiscusses)
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
