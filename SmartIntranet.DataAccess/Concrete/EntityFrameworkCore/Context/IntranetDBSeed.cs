using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SmartIntranet.Entities.Concrete;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SmartIntranet.Entities.Concrete.Intranet;


namespace SmartIntranet.DataAccess.Concrete.EntityFrameworkCore.Context
{
    public static class IntranetDBSeed
    {
        public static string path = Path.Combine(Directory.GetCurrentDirectory() + "/wwwroot/clauseDocs/");
      public  static  IApplicationBuilder SeedTicketSystem(this IApplicationBuilder app)
        {

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();
                var hasroleAdminAndUser = db.Roles.Where(r => r.Name.Contains("SuperAdmin") ||
                r.Name.Contains("User")).Any();
                if (!db.Settings.Any())
                {
                    db.Settings.Add(new Settings
                    {
                        UserName = "admin@srgroupco.com",

                        TicketPassword = "T!cket2021",
                        TicketHost = "smtp.office365.com",
                        TicketPort = 587,
                        TicketMail = "ticket@srgroupco.com",  
                        
                        HrPassword = "IL234$#@il",
                        HrHost = "smtp.office365.com",
                        HrPort = 587,
                        HrMail = "hr@srgroupco.com",

                        BaseUrl="demoticket.srgroupco.com",
                        CompanyLogo = "logoDefault.png",
                        CompanyName = "SR Group Co.",
                        CompanyAddress = "Babek Plaza, A-block, 3th floor A.Quliyev st. 1131, Baku, Azerbaijan"
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
                //var user2 = new IntranetUser()
                //{
                //    UserName = "MahirTahiroghlu",
                //    Email = "mahir.tahiroghlu@srgroupco.com",
                //    Name = "Mahir",
                //    Surname = "Tahiroglu",
                //    Picture = "Default.png",
                //    //CompanyId = 1,
                //    //DepartmentId = 1,
                //    //PositionId = 1,
                //    EmailConfirmed = true
                //};

                var user = new IntranetUser()
                {
                    UserName = "SuperAdmin",
                    Email = "tahiroglumahir@gmail.com",
                    Name = "Mahir",
                    Surname = "Tahiroglu",
                    Picture = "Default.png",
                    //CompanyId = 1,
                    //DepartmentId = 1,
                    //PositionId = 1,
                    EmailConfirmed = true
                };
                //var foundUser2 = userManager.FindByEmailAsync(user2.Email).Result;

                //if (foundUser2 != null && !userManager.IsInRoleAsync(foundUser2, role.Name).Result)
                //{
                //    userManager.AddToRoleAsync(foundUser2, role.Name).Wait();
                //}
                //else if (foundUser2 == null)
                //{
                //    string password = "123";
                //    var iUserResult = userManager.CreateAsync(user2, password).Result;
                //    if (iUserResult.Succeeded)
                //    {
                //        userManager.AddToRoleAsync(user2, userRole.Name).Wait();
                //    }
                //}

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

        static public IApplicationBuilder SeedClause(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();

                if (!db.Clauses.Any())
                {
                    var recruitment_labor_contract = new Clause()
                    {
                        Name = "İşə qəbul əmək müqaviləsi",
                        Key = "recruitment_labor_contract",
                        FilePath = "recruitment_labor_contract.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = false
                    };

                    var recruitment_privacy = new Clause()
                    {
                        Name = "İşə qəbul məxfilik",
                        Key = "recruitment_privacy",
                        FilePath = "recruitment_privacy.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var recruitment_command = new Clause()
                    {
                        Name = "İşə qəbul əmr",
                        Key = "recruitment_command",
                        FilePath = "recruitment_command.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var recruitment_financial_responsibility = new Clause()
                    {
                        Name = "İşə qəbul tam maddi məsuliyyət ",
                        Key = "recruitment_financial_responsibility",
                        FilePath = "recruitment_financial_responsibility.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var personal_change_extra_work_place = new Clause()
                    {
                        Name = "Kadr dəyişikliyi müqaviləyə əlavə iş yeri ",
                        Key = "personal_change_extra_work_place",
                        FilePath = "personal_change_extra_work_place.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var personal_change_extra_work_graphic = new Clause()
                    {
                        Name = "Kadr dəyişikliyi müqaviləyə əlavə iş qrafiki ",
                        Key = "personal_change_extra_work_graphic",
                        FilePath = "personal_change_extra_work_graphic.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = false
                    };

                    var personal_change_extra_vacation = new Clause()
                    {
                        Name = "Kadr dəyişikliyi müqaviləyə əlavə məzuniyyət ",
                        Key = "personal_change_extra_vacation",
                        FilePath = "personal_change_extra_vacation.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };
                    var personal_change_command_salary = new Clause()
                    {
                        Name = "Kadr dəyişikliyi əmr maaş",
                        Key = "personal_change_command_salary",
                        FilePath = "personal_change_command_salary.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };
                    var personal_change_extra_salary = new Clause()
                    {
                        Name = "Kadr dəyişikliyi müqaviləyə əlavə maaş",
                        Key = "personal_change_extra_salary",
                        FilePath = "personal_change_extra_salary.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var personal_change_command_position = new Clause()
                    {
                        Name = "Kadr dəyişikliyi əmr vəzifə",
                        Key = "personal_change_command_position",
                        FilePath = "personal_change_command_position.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };
                    var personal_change_extra_position = new Clause()
                    {
                        Name = "Kadr dəyişikliyi müqaviləyə əlavə vəzifə",
                        Key = "personal_change_extra_position",
                        FilePath = "personal_change_extra_position.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var personal_change_command_salary_position = new Clause()
                    {
                        Name = "Kadr dəyişikliyi əmr maaş və vəzifə",
                        Key = "personal_change_command_salary_position",
                        FilePath = "personal_change_command_salary_position.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var personal_change_extra_salary_position = new Clause()
                    {
                        Name = "Kadr dəyişikliyi müqaviləyə əlavə maaş və vəzifə",
                        Key = "personal_change_extra_salary_position",
                        FilePath = "personal_change_extra_salary_position.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    // Ezamiyyet
                    var business_trip_command = new Clause()
                    {
                        Name = "Ezamiyyət əmr",
                        Key = "business_trip_command",
                        FilePath = "business_trip_command.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };
                    // Mezuniyyet
                    var vacation_labor = new Clause()
                    {
                        Name = "Əmək məzuniyyəti",
                        Key = "vacation_labor",
                        FilePath = "vacation_labor.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var vacation_without_price = new Clause()
                    {
                        Name = "Ödənişsiz məzuniyyət",
                        Key = "vacation_without_price",
                        FilePath = "vacation_without_price.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var vacation_edu = new Clause()
                    {
                        Name = "Təhsil məzuniyyəti",
                        Key = "vacation_edu",
                        FilePath = "vacation_edu.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var vacation_pregnancy = new Clause()
                    {
                        Name = "Analıq məzuniyyəti",
                        Key = "vacation_pregnancy",
                        FilePath = "vacation_pregnancy.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var vacation_social = new Clause()
                    {
                        Name = "Sosial məzuniyyət",
                        Key = "vacation_social",
                        FilePath = "vacation_social.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    // Termination

                    var termination_base = new Clause()
                    {
                        Name = "Adi Xitam",
                        Key = "termination_base",
                        FilePath = "termination_base.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var termination_reduction_agree = new Clause()
                    {
                        Name = "İxtisar Xitamı (razılıq verilmiş)",
                        Key = "termination_reduction_agree",
                        FilePath = "termination_reduction_agree.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    var termination_reduction_not_agree = new Clause()
                    {
                        Name = "İxtisar Xitamı (razılıq verilməmiş)",
                        Key = "termination_reduction_not_agree",
                        FilePath = "termination_reduction_not_agree.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };

                    // Mqavile uzadilmasi

                    var long_contract = new Clause()
                    {
                        Name = "Müqavilə uzadılması",
                        Key = "long_contract",
                        FilePath = "long_contract.docx",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now,
                        IsDeletable = false,
                        IsBackground = true
                    };


                    // Ise qebul
                    db.Clauses.Add(recruitment_labor_contract);
                    db.Clauses.Add(recruitment_privacy);
                    db.Clauses.Add(recruitment_command);
                    db.Clauses.Add(recruitment_financial_responsibility);

                    // Kadr deyisikliyi
                    db.Clauses.Add(personal_change_extra_work_graphic);
                    db.Clauses.Add(personal_change_extra_work_place);
                    db.Clauses.Add(personal_change_extra_vacation);
                    db.Clauses.Add(personal_change_command_salary);
                    db.Clauses.Add(personal_change_extra_salary);
                    db.Clauses.Add(personal_change_command_position);
                    db.Clauses.Add(personal_change_extra_position);
                    db.Clauses.Add(personal_change_command_salary_position);
                    db.Clauses.Add(personal_change_extra_salary_position);

                    // Məzuniyyət
                    db.Clauses.Add(vacation_labor);
                    db.Clauses.Add(vacation_edu);
                    db.Clauses.Add(vacation_social);
                    db.Clauses.Add(vacation_pregnancy);
                    db.Clauses.Add(vacation_without_price);

                    // Ezamiyyet
                    db.Clauses.Add(business_trip_command);

                    // Xitam
                    db.Clauses.Add(termination_base);
                    db.Clauses.Add(termination_reduction_agree);
                    db.Clauses.Add(termination_reduction_not_agree);

                    // Muqavile uzadilmasi
                    db.Clauses.Add(long_contract);

                    db.SaveChanges();
                }

            }

            return app;
        }

        static public IApplicationBuilder SeedContractType(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();

                if (!db.ContractTypes.Any())
                {
                    var work_accept = new ContractType()
                    {
                        Name = "İşə qəbul",
                        Key = "WORK_ACCEPT",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var personal_chg = new ContractType()
                    {
                        Name = "Kadr dəyişikliyi",
                        Key = "PERSONAL_CHG",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var vacation = new ContractType()
                    {
                        Name = "Məzuniyyət",
                        Key = "VACATION",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var business_trip = new ContractType()
                    {
                        Name = "Ezamiyyət",
                        Key = "BUSINESS_TRIP",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var termination = new ContractType()
                    {
                        Name = "Xitam",
                        Key = "TERMINATION",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var longContract = new ContractType()
                    {
                        Name = "Müqavilə uzadılması",
                        Key = "LONG_CONTRACT",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    db.ContractTypes.Add(work_accept);
                    db.ContractTypes.Add(personal_chg);
                    db.ContractTypes.Add(vacation);
                    db.ContractTypes.Add(business_trip);
                    db.ContractTypes.Add(termination);
                    db.ContractTypes.Add(longContract);

                    db.SaveChanges();
                }

            }

            return app;
        }

        static public IApplicationBuilder SeedVacationType(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();

                if (!db.VacationTypes.Any())
                {
                    var labor = new VacationType()
                    {
                        Name = "Əmək məzuniyyəti",
                        Key = "labor",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var without_price = new VacationType()
                    {
                        Name = "Ödənişsiz məzuniyyət",
                        Key = "without_price",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var pregnancy = new VacationType()
                    {
                        Name = "Analıq məzuniyyəti",
                        Key = "pregnancy",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var edu = new VacationType()
                    {
                        Name = "Təhsil məzuniyyəti",
                        Key = "edu",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var social = new VacationType()
                    {
                        Name = "Sosial qulluq məzuniyyəti",
                        Key = "social",
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    db.VacationTypes.Add(labor);
                    db.VacationTypes.Add(without_price);
                    db.VacationTypes.Add(edu);
                    db.VacationTypes.Add(pregnancy);
                    db.VacationTypes.Add(social);

                    db.SaveChanges();
                }

            }

            return app;
        }

        static public IApplicationBuilder SeedNonWorkingGraphics(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();

                if (!db.NonWorkingYears.Any())
                {
                    var working_year = new NonWorkingYear()
                    {
                        Year = DateTime.Now.ToString("yyyy"),
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };


                    db.NonWorkingYears.Add(working_year);


                    db.SaveChanges();
                }

                if (!db.WorkGraphics.Any())
                {
                    var year = DateTime.Now.ToString("yyyy");
                    var day_5 = new WorkGraphic()
                    {
                        Name = "5 günlük",
                        Key = "five_day",
                        NonWorkingYearId = db.NonWorkingYears.FirstOrDefault(x => x.Year == year).Id,
                        Monday = 8,
                        Tuesday = 8,
                        Wednesday = 8,
                        Thursday = 8,
                        Friday = 8,
                        Saturday = 8,
                        Sunday = 0,
                        WorkStart = DateTime.ParseExact("09:00", "HH:mm", null),
                        WorkEnd = DateTime.ParseExact("18:00", "HH:mm", null),
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };

                    var day_6 = new WorkGraphic()
                    {
                        Name = "6 günlük",
                        Key = "six_day",
                        NonWorkingYearId = db.NonWorkingYears.FirstOrDefault(x => x.Year == year).Id,
                        Monday = 7,
                        Tuesday = 7,
                        Wednesday = 7,
                        Thursday = 7,
                        Friday = 7,
                        Saturday = 5,
                        Sunday = 0,
                        WorkStart = DateTime.ParseExact("09:00", "HH:mm", null),
                        WorkEnd = DateTime.ParseExact("17:00", "HH:mm", null),
                        IsDeleted = false,
                        CreatedDate = DateTime.Now
                    };


                    db.WorkGraphics.Add(day_5);
                    db.WorkGraphics.Add(day_6);


                    db.SaveChanges();
                }

            }

            return app;
        }

        static public IApplicationBuilder SeedPlace(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();

                if (!db.Places.Any())
                {
                    string filePath = "wwwroot/seedJson/places.json";
                    string json = File.ReadAllText(filePath);
                    List<Place> places = JsonConvert.DeserializeObject<List<Place>>(json);

                    db.Places.AddRange(places);
                    db.SaveChanges();
                }
            }
            return app;
        }

        static public IApplicationBuilder SeedTerminationItem(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<IntranetContext>();

                if (!db.TerminationItems.Any())
                {
                    string filePath = "wwwroot/seedJson/termination_item.json";
                    string json = File.ReadAllText(filePath);
                    List<TerminationItem> places = JsonConvert.DeserializeObject<List<TerminationItem>>(json);
                    places.Select(c => { c.IsDeleted = false; c.CreatedDate = DateTime.Now; return c; }).ToList();

                    db.TerminationItems.AddRange(places);
                    db.SaveChanges();
                }
            }
            return app;
        }


    }
}