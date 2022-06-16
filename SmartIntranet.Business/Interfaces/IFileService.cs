using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Interfaces
{
    public interface IFileService
    {
        Task<string> Upload(IFormFile file, string root = "wwwroot/uploads");
        void Delete(string filename, string deletePath = "wwwroot/uploads");
        string UploadResizedImg(IFormFile file, string root = "wwwroot/uploads");
        void IsExistFolderCreate(string root);
    }
}
