using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile file, string root = "wwwroot/uploads");
        void Delete(string filename, string deletePath = "wwwroot/uploads");
        Task<string> UploadResizedImg(IFormFile file, string root = "wwwroot/uploads");
        void IsExistFolderCreate(string root);
    }
}
