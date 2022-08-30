using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartIntranet.Entities.Concrete.Intranet;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Mapping
{
    public class SettingsMap : IEntityTypeConfiguration<Settings>
    {
        public void Configure(EntityTypeBuilder<Settings> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.UserName).IsRequired();
            //Ticket
            builder.Property(I => I.TicketPassword).IsRequired();
            builder.Property(I => I.TicketHost).IsRequired();
            builder.Property(I => I.TicketPort).IsRequired();
            builder.Property(I => I.TicketMail).IsRequired(); 
            //Hr
            builder.Property(I => I.HrPassword).IsRequired();
            builder.Property(I => I.HrHost).IsRequired();
            builder.Property(I => I.HrPort).IsRequired();
            builder.Property(I => I.HrMail).IsRequired();

            builder.Property(I => I.BaseUrl).IsRequired();

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
