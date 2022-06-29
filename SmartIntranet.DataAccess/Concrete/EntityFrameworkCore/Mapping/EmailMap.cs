using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using SmartIntranet.Entities.Concrete.IntraTicket;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class EmailMap : IEntityTypeConfiguration<SMTPEmailSetting>
    {
        public void Configure(EntityTypeBuilder<SMTPEmailSetting> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.UserName).IsRequired();
            builder.Property(I => I.Password).IsRequired();
            builder.Property(I => I.Host).IsRequired();
            builder.Property(I => I.Port).IsRequired();
            builder.Property(I => I.FromEmail).IsRequired();
            builder.Property(I => I.BaseUrl).IsRequired();

            builder.Property(I => I.IsSSL).HasDefaultValue(false);
            builder.Property(I => I.IsDefault).HasDefaultValue(false);
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
