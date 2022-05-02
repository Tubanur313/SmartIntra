using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using SmartIntranet.Core.Entities.Enum;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System.Linq;


namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public static class IntranetDBSeed
    {
        static public IApplicationBuilder SeedTicketSystem(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();
                var hasroleAdminAndUser = db.Roles.Where(r => r.Name.Contains("SuperAdmin") ||
                r.Name.Contains("User")).Any();
                if (!db.SMTPEmailSettings.Any())
                {
                    db.SMTPEmailSettings.Add(new SMTPEmailSetting
                    {
                        UserName = "admin@srgroupco.com",
                        Password = "T!cket2021",
                        Host = "smtp.office365.com",
                        Port = 587,
                        FromEmail = "ticket@srgroupco.com",
                        BaseUrl="demoticket.srgroupco.com"
                    });

                    db.SaveChangesAsync().GetAwaiter().GetResult();
                }
                //if (!db.Categories.Any())
                //{
                //    db.Categories.Add(new Category
                //    {
                //        Name = "Web",
                //        TicketType=TicketType.Task,
                //        ParentId = null,
                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                //if (!db.CheckLists.Any())
                //{
                //    db.CheckLists.Add(new CheckList
                //    {
                //        Name = "Face Id",
                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                //if (!db.Companies.Any())
                //{
                //    db.Companies.Add(new Company
                //    {
                //        Name = "SR Group .Co",
                //        ParentId = null,
                //        LogoPath = "logoDefault.png"
                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                //if (!db.Departments.Any())
                //{
                //    db.Departments.Add(new Department
                //    {
                //        Name = "IKT",
                //        ParentId = null,
                //        CompanyId = 1,
                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                //if (!db.Positions.Any())
                //{
                //    db.Positions.Add(new Position
                //    {
                //        Name = "IKT Manager",
                //        CompanyId = 1,
                //        DepartmentId = 1,
                //        ParentId = null
                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                if (hasroleAdminAndUser == true)
                {
                    goto end;
                }

                var role = new IntranetRole()
                {
                    Name = "SuperAdmin"
                };
                var userRole = new IntranetRole()
                {
                    Name = "User"
                };



                var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IntranetUser>>();
                var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IntranetRole>>();



                var hasRole = roleManager.RoleExistsAsync(role.Name).Result;
                if (hasRole == true)
                {
                    var roleResult = roleManager.FindByNameAsync(role.Name).Result;
                }
                else
                {
                    var iResult = roleManager.CreateAsync(role).Result;
                    if (!iResult.Succeeded)
                    {
                        goto end;
                    }
                }

                var hasUserRole = roleManager.RoleExistsAsync(userRole.Name).Result;
                if (hasUserRole == true)
                {
                    var roleUserResult = roleManager.FindByNameAsync(userRole.Name).Result;
                }
                else
                {
                    var iUserResult = roleManager.CreateAsync(userRole).Result;
                    if (!iUserResult.Succeeded)
                    {
                        goto end;
                    }
                }


                //if (!db.Companies.Any())
                //{
                //    db.Companies.Add(new Company
                //    {
                //        Name = "Yoxdur"

                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                //if (!db.Departments.Any())
                //{
                //    db.Departments.Add(new Department
                //    {
                //        Name = "Yoxdur",
                //        CompanyId = 1

                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                //if (!db.Positions.Any())
                //{
                //    db.Positions.Add(new Position
                //    {
                //        Name = "Yoxdur",
                //        DepartmentId = 1

                //    });

                //    db.SaveChangesAsync().GetAwaiter().GetResult();
                //};
                var user2 = new IntranetUser()
                {
                    UserName = "MahirTahiroghlu",
                    Email = "mahir.tahiroghlu@srgroupco.com",
                    //FullName = "Mahir Tahiroglu",
                    Picture = "Default.png",
                    //CompanyId = 1,
                    //DepartmentId = 1,
                    //PositionId = 1,
                    EmailConfirmed = true
                };

                var user = new IntranetUser()
                {
                    UserName = "SuperAdmin",
                    Email = "tahiroglumahir@gmail.com",
                    //FullName = "Super Admin",
                    Picture = "Default.png",
                    //CompanyId = 1,
                    //DepartmentId = 1,
                    //PositionId = 1,
                    EmailConfirmed = true
                };
                var foundUser2 = userManager.FindByEmailAsync(user2.Email).Result;

                if (foundUser2 != null && !userManager.IsInRoleAsync(foundUser2, role.Name).Result)
                {
                    userManager.AddToRoleAsync(foundUser2, role.Name).Wait();
                }
                else if (foundUser2 == null)
                {
                    string password = "123";
                    var iUserResult = userManager.CreateAsync(user2, password).Result;
                    if (iUserResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(user2, userRole.Name).Wait();
                    }
                }

                var foundUser = userManager.FindByEmailAsync(user.Email).Result;

                if (foundUser != null && !userManager.IsInRoleAsync(foundUser, role.Name).Result)
                {
                    userManager.AddToRoleAsync(foundUser, role.Name).Wait();
                }
                else if (foundUser == null)
                {
                    string password = "123";
                    var iUserResult = userManager.CreateAsync(user, password).Result;
                    if (iUserResult.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, role.Name).Wait();
                    }
                }

            }

        end:
            return app;
        }
    }
}