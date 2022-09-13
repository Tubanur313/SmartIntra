using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.Inventary;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class StockMap : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn(1000, 1);
            builder.Property(I => I.Name).IsRequired();
            builder.Property(I => I.StockCategoryId).IsRequired();
            builder.Property(I => I.Price);
            builder.Property(I => I.MacAddress);
            builder.Property(I => I.SKU);
            builder.Property(I => I.CompanyId).IsRequired();
            builder.Property(I => I.IntranerUserId);
            builder.Property(I => I.BuyDate);
            builder.Property(I => I.DepreciationPercent);
            //Relation's
            builder.HasOne(d => d.StockCategory)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.StockCategoryId).OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(d => d.IntranetUser)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.IntranerUserId).OnDelete(DeleteBehavior.Restrict);

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
