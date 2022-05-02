using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;

namespace SmartIntranet.Core.Utilities.FileUploader
{
    public interface IFileManager
    {

        Task<string> Upload(IFormFile file, string root = "wwwroot/uploads");
        void Delete(string filename, string deletePath = "wwwroot/uploads");
        string UploadResizedImg(IFormFile file, string root = "wwwroot/uploads");
        void IsExistFolderCreate(string root);
    }
    public class FileManager : IFileManager
    {
        public async Task<string> Upload(IFormFile file, string root = "wwwroot/uploads")
        {
            IsExistFolderCreate(root);
            var fileName = DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetExtension(file.FileName);

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), root, fileName);

            using (var stream = new FileStream(uploadPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        public void Delete(string filename, string deletePath = "wwwroot/uploads")
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), deletePath, filename);
            if (File.Exists(file))
                File.Delete(file);

        }
        public string UploadResizedImg(IFormFile file, string root = "wwwroot/uploads")
        {
            IsExistFolderCreate(root);
            string imageName = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), root + imageName);
            using (var image = Image.Load(file.OpenReadStream()))
            {
                string newSize = ImageResize(image, 600, 600);
                string[] sizeArray = newSize.Split(",");
                image.Mutate(i => i.Resize(Convert.ToInt32(sizeArray[1]),
                    Convert.ToInt32(sizeArray[0])));
                image.Save(path);
            }

            return imageName;
        }
        public string ImageResize(Image img, int MaxWidth, int MaxHeight)
        {
            if (img.Width > MaxWidth || img.Height > MaxHeight)
            {
                double widthratio = (double)img.Width / (double)MaxWidth;
                double heightratio = (double)img.Height / (double)MaxHeight;
                double ratio = Math.Max(widthratio, heightratio);
                int newWidth = (int)(img.Width / ratio);
                int newHeight = (int)(img.Height / ratio);
                return newHeight.ToString() + "," + newWidth.ToString();
            }
            else
            {
                return img.Height.ToString() + "," + img.Width.ToString();
            }
        }
        public void IsExistFolderCreate(string root)
        {
            if (!Directory.Exists(root))
                Directory.CreateDirectory(root);
        }
    }
}
