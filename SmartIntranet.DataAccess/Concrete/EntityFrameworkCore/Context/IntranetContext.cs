using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.IntraTicket;
using SmartIntranet.Entities.Concrete.Inventary;
using SmartIntranet.Entities.Concrete.Membership;
using System.Reflection;

namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public class IntranetContext : IdentityDbContext<IntranetUser, IntranetRole, int, IntranetUserClaim, IntranetUserRole, IntranetUserLogin, IntranetRoleClaim, IntranetUserToken>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Xadica's local connection string
             optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=RealIntranetSmart2;Trusted_Connection=False;MultipleActiveResultSets=true"); 

            optionsBuilder.UseSqlServer(@"Server=178.63.85.231;Initial Catalog=DemoIntranet3;User Id=mahir;Password=p8Mfs4&6;MultipleActiveResultSets=true");

            //Ilkin's local connection string
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=IntranetSmartTest;Trusted_Connection=False;MultipleActiveResultSets=true");

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
        public DbSet<News> News { get; set; }
        public DbSet<NewsFile> NewsFiles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryNews> CategoryNews { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<UserContractFile> UserContractFiles { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<NonWorkingYear> NonWorkingYears { get; set; }
        public DbSet<NonWorkingDay> NonWorkingDays { get; set; }
        public DbSet<WorkGraphic> WorkGraphics { get; set; }
        public DbSet<WorkCalendar> WorkCalendars { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<ContractFile> ContractFiles { get; set; }
        public DbSet<LongContract> LongContracts { get; set; }
        public DbSet<LongContractFile> LongContractFiles { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }
        public DbSet<UserExperience> UserExperiences { get; set; }
        public DbSet<Clause> Clauses { get; set; }
        public DbSet<UserVacationRemain> UserVacationRemains { get; set; }
        public DbSet<PersonalContract> PersonalContracts { get; set; }
        public DbSet<PersonalContractFile> PersonalContractFiles { get; set; }
        public DbSet<Cause> Causes { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<ReportEmployee> ReportEmployees { get; set; }
        public DbSet<TerminationItem> TerminationItems { get; set; }
        public DbSet<TerminationContract> TerminationContracts { get; set; }
        public DbSet<TerminationContractFile> TerminationContractFiles { get; set; }
        public DbSet<VacationType> VacationTypes { get; set; }
        public DbSet<VacationContract> VacationContracts { get; set; }
        public DbSet<VacationContractFile> VacationContractFiles { get; set; }
        public DbSet<BusinessTrip> BusinessTrips { get; set; }
        public DbSet<BusinessTripUser> BusinessTripUsers { get; set; }
        public DbSet<BusinessTripFile> BusinessTripFiles { get; set; }
        public DbSet<CategoryTicket> CategoryTickets { get; set; }
        public DbSet<SMTPEmailSetting> SMTPEmailSettings { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<ConfirmTicketUser> ConfirmTicketUsers { get; set; }
        public DbSet<Discussion> Discussions { get; set; }
        public DbSet<Entrance> Entrances { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCheckList> TicketCheckLists { get; set; }
        public DbSet<Watcher> Watchers { get; set; }
        public DbSet<TicketOrder> TicketOrders { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockCategory> StockCategories { get; set; }
        public DbSet<StockImage> StockImages { get; set; }
        public DbSet<StockDiscuss> StockDiscusses { get; set; }
        #endregion


    }
}
