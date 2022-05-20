using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Membership;
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
            #region Mapping
            //modelBuilder.ApplyConfiguration(new VacancyMap());
            //modelBuilder.ApplyConfiguration(new UserContractFileMap());
            //modelBuilder.ApplyConfiguration(new GradeMap());
            //modelBuilder.ApplyConfiguration(new NewsFileMap());
            //modelBuilder.ApplyConfiguration(new NewsMap());
            //modelBuilder.ApplyConfiguration(new CategoryMap());
            //modelBuilder.ApplyConfiguration(new CategoryNewsMap());
            //modelBuilder.ApplyConfiguration(new CategoryTicketMap());
            //modelBuilder.ApplyConfiguration(new EmailMap());
            //modelBuilder.ApplyConfiguration(new CheckListMap());
            //modelBuilder.ApplyConfiguration(new IntranetUserMap());
            //modelBuilder.ApplyConfiguration(new IntranetRoleMap());
            //modelBuilder.ApplyConfiguration(new CompanyMap());
            //modelBuilder.ApplyConfiguration(new ConfirmTicketUserMap());
            //modelBuilder.ApplyConfiguration(new DepartmentMap());
            //modelBuilder.ApplyConfiguration(new PositionMap());
            //modelBuilder.ApplyConfiguration(new DiscussionMap());
            //modelBuilder.ApplyConfiguration(new EntranceMap());
            //modelBuilder.ApplyConfiguration(new PhotoMap());
            //modelBuilder.ApplyConfiguration(new TicketMap());
            //modelBuilder.ApplyConfiguration(new TicketCheckListMap());
            //modelBuilder.ApplyConfiguration(new WatcherMap());
            //modelBuilder.ApplyConfiguration(new OrderMap());
            //modelBuilder.ApplyConfiguration(new TicketOrderMap());

            #endregion

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
