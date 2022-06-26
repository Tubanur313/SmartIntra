using AutoMapper;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SmartIntranet.DTO.DTOs.AppUserDto;
using SmartIntranet.Entities.Concrete.Intranet;
using SmartIntranet.Entities.Concrete.Membership;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Web.Controllers
{
    [Authorize]
    public class BaseIdentityController : Controller
    {
        protected readonly UserManager<IntranetUser> _userManager;
        //protected readonly RoleManager<IntranetUser> _roleManager;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        protected readonly SignInManager<IntranetUser> _signInManager;
        protected readonly IMapper _map;
        private readonly List<LevelType> levels = new List<LevelType>();
        public BaseIdentityController
            (
            UserManager<IntranetUser> userManager,
            IHttpContextAccessor httpContextAccessor,
            SignInManager<IntranetUser> signInManager,
            IMapper map
            )
        {
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _signInManager = signInManager;
            _map = map;

            levels.Add(new LevelType() { Id = EducationLevelConstant.PRIMARY_VOCATIONAL, Name = "İlkin peşə təhsili" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.GENERAL_SECONDARY, Name = "Ümumi orta təhsil" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.BACHELORS, Name = "Bakalavr" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.MASTER, Name = "Magistratura" });
            levels.Add(new LevelType() { Id = EducationLevelConstant.VOCATIONAL, Name = "Orta ixtisas" });

        }

        protected int GetSignInUserId()
        {
            return _userManager.FindByNameAsync(User.Identity.Name).Result.Id;
        }
        //protected string GetSignInUserRole()
        //{
        //    return _userManager.GetRolesAsync()
        //}


        protected void AddError(IEnumerable<IdentityError> errors)
        {
            foreach (var item in errors)
            {
                ModelState.AddModelError("", item.Description);
            }
        }

        protected Dictionary<string, string> PdfStaticKeys(Dictionary<string, string> formatKeys, IntranetUser usr, Company company, IntranetUser company_director)
        {
            formatKeys.Add("companyDirector", company_director.Name + " " + company_director.Surname + " " + company_director.Fathername);
            formatKeys.Add("employeeFull", $"{usr.Surname} {usr.Name} {usr.Fathername} {(usr.Gender == "MALE" ? "oğlu" : usr.Gender == "FEMALE" ? "qızı" : "")}");
            formatKeys.Add("employeeStartWork", usr.StartWorkDate.ToString("dd.MM.yyyy"));
            formatKeys.Add("position", usr.Position.Name);
            formatKeys.Add("leaderPosition", company.LeaderPosition);
            formatKeys.Add("nationality", usr.Citizenship);
            formatKeys.Add("idCardNumber", usr.IdCardNumber);
            formatKeys.Add("idCardGivenDate", usr.IdCardGiveDate.ToString("dd.MM.yyyy"));
            formatKeys.Add("idCardGivenPlace", usr.IdCardGivePlace);
            formatKeys.Add("educationLevel", levels.FirstOrDefault(x => x.Id == usr.EducationLevel).Name);
            formatKeys.Add("profession", usr.Profession);
            formatKeys.Add("graduatedPlace", usr.GraduatedPlace);
            formatKeys.Add("salaryFull", usr.Salary + " (" + ConvertAmount(usr.Salary) + ")");
            formatKeys.Add("salaryShort", usr.Salary.ToString());
            formatKeys.Add("vacation", usr.VacationMainDay.ToString());
            formatKeys.Add("extraVacation", (usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild).ToString());
            formatKeys.Add("vacationExtraNature", usr.VacationExtraNature.ToString());
            formatKeys.Add("vacationExtraExperience", usr.VacationExtraExperience.ToString());
            formatKeys.Add("vacationExtraChild", usr.VacationExtraChild.ToString());
            formatKeys.Add("vacationAll", (usr.VacationMainDay + usr.VacationExtraNature + usr.VacationExtraExperience + usr.VacationExtraChild).ToString());
            formatKeys.Add("companyName", company.Name);
            formatKeys.Add("employeeAddress", usr.RegisterAdress);
            formatKeys.Add("companyAddress", company.Address);
            formatKeys.Add("companyTin", company.Tin);
            formatKeys.Add("companyAccount", company.BankAccountNumber);
            formatKeys.Add("companyBankName", company.BankName);
            formatKeys.Add("companyBankTin", company.BankTin);
            formatKeys.Add("companyBankCode", company.BankCode);
            formatKeys.Add("companyBankSwift", company.SWIFTCode);
            formatKeys.Add("companyCorrespondentAccount", company.CorrespondentAccountNumber);

            return formatKeys;
        }

        protected StringBuilder PdfFormatKeys(Dictionary<string, string> formatKeys, StringBuilder content, int count = 1)
        {
            content = DuplicateRow(content, count);
            foreach (var item in formatKeys)
            {
                content = content.Replace("[" + $"{item.Key.Trim()}" + "]", item.Value);
            }
            return content;
        }

        protected StringBuilder DuplicateRow(StringBuilder str, int count)
        {
            int startIndex = str.ToString().IndexOf("{");
            int endIndex = str.ToString().IndexOf("}");
            if (startIndex == -1 || endIndex == -1) return str;
            string str2 = str.ToString().Substring(startIndex, endIndex - startIndex);
            string str4 = "";
            string str3 = "";
            for (int i = 0; i < count; i++)
            {
                str4 = str2.Replace("]", $"_{i}]").ToString();
                str3 += str4;
            }
            str = str.Replace(str2, str3).Replace("{", "").Replace("}", "");
            return str;
        }

        protected async Task<StringBuilder> GetDocxContent(string filePath, Dictionary<string, string> formatKeys)
        {
            filePath = "wwwroot/clauseDocs/" + filePath;

            byte[] byteArray = await System.IO.File.ReadAllBytesAsync(filePath);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int)byteArray.Length);


                using (var doc = WordprocessingDocument.Open(stream, true))
                {

                    var test_item = "";
                    var body = doc.MainDocumentPart.Document.Body;
                    var paras = body.Elements<Paragraph>();
                    bool flag = false;
                    var aa = doc.MainDocumentPart.Document.Body.Descendants<Text>();
                    foreach (var text in doc.MainDocumentPart.Document.Body.Descendants<Text>()) // <<< Here
                    {

                        foreach (var el in text.Text)
                        {
                            if (flag && el == ' ')
                            {
                                continue;
                            }
                            test_item += el;
                            if (el == '[')
                            {
                                flag = true;
                            }
                            if (el == ']')
                            {
                                flag = false;
                            }
                        }

                        if (flag)
                        {
                            text.Text = "";
                        }
                        else
                        {
                            text.Text = test_item;
                            test_item = null;
                        }

                        //if (text.Text.Trim().StartsWith("[") && !text.Text.Trim().EndsWith("]"))
                        //{
                        //    test_item = text.Text.Trim();
                        //    text.Text = "";
                        //}
                        //else if (text.Text.Trim().StartsWith("[") && text.Text.Trim().EndsWith("]"))
                        //{
                        //    if (formatKeys.ContainsKey(text.Text))
                        //    {
                        //        text.Text = formatKeys.GetValueOrDefault(test_item);
                        //    }

                        //}
                        //else if (!text.Text.Trim().StartsWith("[") && !text.Text.Trim().EndsWith("]") && test_item!=null && test_item != "")
                        //{
                        //    test_item += text.Text.Trim();
                        //    text.Text = "";
                        //}
                        //else if (!text.Text.Trim().StartsWith("[") && text.Text.Trim().EndsWith("]"))
                        //{
                        //    test_item += text.Text.Trim();
                        //    string test_key = "";
                        //    if (test_item.Length > 1)
                        //        test_key = test_item.Substring(1, test_item.Length - 2);
                        //    if (formatKeys.ContainsKey(test_key))
                        //    {
                        //        text.Text = formatKeys.GetValueOrDefault(test_key);
                        //    }

                        //    test_item = null;
                        //}

                    }

                    doc.MainDocumentPart.Document.Save();
                    StringBuilder docText = new StringBuilder();
                    using (StreamReader sr = new StreamReader(doc.MainDocumentPart.GetStream()))
                    {
                        return docText.Append(sr.ReadToEnd());
                    }

                }
            }
        }

        string ConvertAmount(double amount)
        {
            try
            {
                int amount_int = (int)amount;
                int amount_dec = (int)Math.Round((amount - (double)(amount_int)) * 100);
                if (amount_dec == 0)
                {
                    return ConvertSalary(amount_int) + " manat";
                }
                else
                {
                    return ConvertSalary(amount_int) + " manat " + ConvertSalary(amount_dec) + " qəpik";
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return "";
        }

        string ConvertSalary(int i)
        {
            string[] units = { "sıfır", "bir", "iki", "üç", "dörd", "beş", "altı", "yeddi", "səkkiz", "doqquz", "on" };
            string[] tens = { "sıfır", "on", "iyirmi", "otuz", "qırx", "əlli", "altmış", "yetmiş", "səksən", "doxsan" };
            if (i < 10)
            {
                return units[i];
            }
            if (i < 100)
            {
                return tens[i / 10] + ((i % 10 > 0) ? " " + ConvertSalary(i % 10) : "");
            }
            if (i < 1000)
            {
                return (units[i / 100] == "bir" ? "" : units[i / 100]) + " yüz "
                        + ((i % 100 > 0) ? ConvertSalary(i % 100) : "");
            }
            if (i < 100000)
            {
                return (ConvertSalary(i / 1000) == "bir" ? "" : ConvertSalary(i / 1000)) + " min "
                + ((i % 1000 > 0) ? " " + ConvertSalary(i % 1000) : "");
            }
            return ConvertSalary(i / 1000000000) + " "
                    + ((i % 1000000000 > 0) ? " " + ConvertSalary(i % 1000000000) : "");
        }

        protected async Task<string> AddFile(string root, IFormFile profile, string fileName = null)
        {
            string imageName = fileName == null ? (Guid.NewGuid() + System.IO.Path.GetExtension(profile.FileName)) : fileName;
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), root + imageName);
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await profile.CopyToAsync(stream);
            }

            return imageName;
        }

        protected async Task<string> AddContractFile(string filePath, StringBuilder content)
        {
            filePath = "wwwroot/clauseDocs/" + filePath;
            string fileName = Guid.NewGuid() + System.IO.Path.GetExtension(".docx");
            byte[] byteArray = await System.IO.File.ReadAllBytesAsync(filePath);
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(byteArray, 0, (int)byteArray.Length);
                using (var doc = WordprocessingDocument.Open(stream, true))
                {
                    using (StreamWriter writer = new StreamWriter(doc.MainDocumentPart.GetStream(FileMode.Create)))
                    {
                        writer.Write(content);
                    }
                }
                string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/contractDocs/" + fileName);
                System.IO.File.WriteAllBytes(path, stream.ToArray());
            }
            return fileName;
        }

        protected string DeleteFile(string root, string fileName)
        {
            string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), root + fileName);
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();
                return "fayl uğurla silindi";
            }
            else
            {
                return "fayl movcud deyil";
            }
        }
    }
}
