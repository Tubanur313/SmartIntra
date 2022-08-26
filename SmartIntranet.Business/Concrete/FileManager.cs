using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SmartIntranet.Business.Interfaces;
using SmartIntranet.Core.Extensions;
using System;
using System.IO;
using System.Threading.Tasks;

namespace SmartIntranet.Business.Concrete
{
    public class FileManager : IFileService
    {
        public async Task<string> Upload(IFormFile file, string root = "wwwroot/uploads")
        {
            IsExistFolderCreate(root);
            string fileName =NameOperation.CharacterRegulatory(Path.GetFileNameWithoutExtension(file.FileName) )+ DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetExtension(file.FileName);
            //string fileName = await FileRenameAsync(file.FileName, root);

            var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), root, fileName);

           await using (FileStream stream = new FileStream(uploadPath, FileMode.Create,FileAccess.Write,FileShare.None,1024*1024,useAsync:false))
            {
                await file.CopyToAsync(stream);
                await stream.FlushAsync();
            }

            return fileName;
        }
        public void Delete(string filename, string deletePath = "wwwroot/uploads")
        {
            var file = Path.Combine(Directory.GetCurrentDirectory(), deletePath, filename);
            if (File.Exists(file))
                File.Delete(file);

        }
        public async Task<string> UploadResizedImg(IFormFile file, string root = "wwwroot/uploads")
        {
            IsExistFolderCreate(root);
            string imageName = NameOperation.CharacterRegulatory(Path.GetFileNameWithoutExtension(file.FileName)) + DateTime.Now.ToString("yyyyMMddHHmmssff") + Path.GetExtension(file.FileName);
            string path = Path.Combine(Directory.GetCurrentDirectory(), root + imageName);
            using (Image image =await Image.LoadAsync(file.OpenReadStream()))
            {
                string newSize = ImageResize(image, 600, 600);
                string[] sizeArray = newSize.Split(",");
                image.Mutate(i => i.Resize(Convert.ToInt32(sizeArray[1]),
                    Convert.ToInt32(sizeArray[0])));
               await image.SaveAsync(path);
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
                return  newHeight.ToString() + "," + newWidth.ToString();
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

        //async Task<string> FileRenameAsync(string fileName,string root,bool first=true)
        //{
        //    string newFileName = await Task.Run<string>(async () =>
        //    {
        //        string extension = Path.GetExtension(fileName);
        //        string newFileName = string.Empty;
        //        if (first)
        //        {
        //            string oldName = Path.GetFileNameWithoutExtension(fileName);
        //            newFileName = $"{NameOperation.CharacterRegulatory(oldName)}{extension}";
        //        }
        //        else
        //        {
        //            newFileName = fileName;
        //            int indexNo1 = newFileName.IndexOf("-");
        //            if (indexNo1 == -1)
        //                newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";
        //            else
        //            {
        //                int lastIndex = 0;
        //                while (true)
        //                {
        //                    lastIndex = indexNo1;
        //                    indexNo1 = newFileName.IndexOf("-", indexNo1 + 1);
        //                    if (indexNo1 == -1)
        //                    {
        //                        indexNo1 = lastIndex;
        //                        break;
        //                    }
        //                }

        //                int indexNo2 = newFileName.IndexOf(".");
        //                string fileNo = newFileName.Substring(indexNo1 + 1, indexNo2 - indexNo1 - 1);

        //                if (int.TryParse(fileNo, out int _fileNo))
        //                {
        //                    _fileNo++;
        //                    newFileName = newFileName.Remove(indexNo1 + 1, indexNo2 - indexNo1 - 1)
        //                                        .Insert(indexNo1 + 1, _fileNo.ToString());
        //                }
        //                else
        //                    newFileName = $"{Path.GetFileNameWithoutExtension(newFileName)}-2{extension}";

        //            }
        //        }

        //        //if (File.Exists($"{path}\\{newFileName}"))
        //        if (hasFileMethod(pathOrContainerName, newFileName))
        //            return await FileRenameAsync(pathOrContainerName, newFileName, hasFileMethod, false);
        //        else
        //            return newFileName;
        //    });

        //    return newFileName;
        //}
    }
    
}
