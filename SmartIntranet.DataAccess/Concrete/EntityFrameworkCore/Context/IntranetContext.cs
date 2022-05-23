using SmartIntranet.Entities.Concrete.Membership;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using System.Reflection;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class IntranetContext : IdentityDbContext<IntranetUser, IntranetRole, int, IntranetUserClaim, IntranetUserRole, IntranetUserLogin, IntranetRoleClaim, IntranetUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=178.63.85.231;Initial Catalog=DemoIntranet;User Id=mahir;Password=p8Mfs4&6;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(modelBuilder);

            #region Membership

            modelBuilder.Entity<IntranetUser>(e =>
            {
                e.ToTable("Users", "Membership");
            });
            modelBuilder.Entity<IntranetRole>(e =>
            {
                e.ToTable("Roles", "Membership");
            });
            modelBuilder.Entity<IntranetUserRole>(e =>
            {
                e.ToTable("UserRoles", "Membership");
            });
            modelBuilder.Entity<IntranetUserClaim>(e =>
            {
                e.ToTable("UserClaims", "Membership");
            });
            modelBuilder.Entity<IntranetRoleClaim>(e =>
            {
                e.ToTable("RoleClaims", "Membership");
            });
            modelBuilder.Entity<IntranetUserLogin>(e =>
            {
                e.ToTable("UserLogins", "Membership");
            });
            modelBuilder.Entity<IntranetUserToken>(e =>
            {
                e.ToTable("UserTokens", "Membership");
            });
            #endregion
        }

        #region DbSet<>
        public DbSet<UserContractFile> UserContractFiles { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<NewsFile> NewsFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryNews> CategoryNews { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<CategoryTicket> CategoryTickets { get; set; }
        public DbSet<SMTPEmailSetting> SMTPEmailSettings { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ConfirmTicketUser> ConfirmTicketUsers { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCheckList> TicketCheckLists { get; set; }
        public DbSet<Watcher> Watchers { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        #endregion


    }
}
