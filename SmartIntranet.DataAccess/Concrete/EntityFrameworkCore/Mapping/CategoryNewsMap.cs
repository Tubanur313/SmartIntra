﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.Intranet;

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
