using SmartIntranet.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class CategoryNewsMap : IEntityTypeConfiguration<CategoryNews>
    {


        public void Configure(EntityTypeBuilder<CategoryNews> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();

            builder.HasIndex(I => new { I.NewsId, I.CategoryId }).IsUnique();


        }

        
    }
}
