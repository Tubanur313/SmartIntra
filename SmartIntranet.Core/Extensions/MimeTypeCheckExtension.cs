using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SmartIntranet.Core.Extensions
{
    static public partial class MimeTypeCheckExtension
    {
        /// <summary>
        /// chek list of images mime extension
        /// </summary>
        /// <param name="image"></param>
        /// <returns>bool type</returns>
        static public bool İsImage(this List<IFormFile> image)
        {
            List<bool> resultList = new List<bool>();
            for (int i = 0; i < image.Count; i++)
            {
                if (
                image[i].ContentType != "image/jpeg" &&
                image[i].ContentType != "image/png" &&
                image[i].ContentType != "image/gif" &&
                image[i].ContentType != "image/webp" &&
                image[i].ContentType != "image/svg"
                )
                {
                    resultList.Add(false);
                }
            }
            if (resultList.Count > 0)
            {
                return false;
            }
            else
            {
            return true;
            }
        }
        /// <summary>
        /// chek image mime extension
        /// </summary>
        /// <param name="image"></param>
        /// <returns>bool type</returns>
        static public bool İsImage(this IFormFile image)
        {

            if (
            image.ContentType != "image/jpeg" &&
            image.ContentType != "image/png" &&
            image.ContentType != "image/gif" &&
            image.ContentType != "image/webp" &&
            image.ContentType != "image/svg"
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        }




        /// <summary>
        /// chek list of documents mime extension
        /// </summary>
        /// <param name="docs"></param>
        /// <returns>bool type</returns>
        static public bool İsDocument(this List<IFormFile> docs)
        {
            List<bool> resultList = new List<bool>();
            for (int i = 0; i < docs.Count; i++)
            {
                if (
                docs[i].ContentType != "application/msword" &&
                docs[i].ContentType != "application/vnd.ms-word.document.macroEnabled.12" &&
                docs[i].ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document" &&
                docs[i].ContentType != "application/vnd.ms-powerpoint" &&
                docs[i].ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" &&
                docs[i].ContentType != "application/vnd.ms-excel" &&
                docs[i].ContentType != "application/vnd.openxmlformats-officedocument.presentationml.slideshow" &&
                docs[i].ContentType != "application/vnd.openxmlformats-officedocument.presentationml.presentation" &&
                docs[i].ContentType != "text/plain" &&
                docs[i].ContentType != "application/pdf" 
                )
                {
                    resultList.Add(false);
                }
            }
            if (resultList.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// chek doc mime extension
        /// </summary>
        /// <param name="doc"></param>
        /// <returns>bool type</returns>
        static public bool İsDocument(this IFormFile doc)
        {
            if (
            doc.ContentType != "application/msword" &&
            doc.ContentType != "application/vnd.ms-word.document.macroEnabled.12" &&
            doc.ContentType != "application/vnd.openxmlformats-officedocument.wordprocessingml.document" &&
            doc.ContentType != "application/vnd.ms-powerpoint" &&
            doc.ContentType != "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet" &&
            doc.ContentType != "application/vnd.ms-excel" &&
            doc.ContentType != "application/vnd.openxmlformats-officedocument.presentationml.slideshow" &&
            doc.ContentType != "application/vnd.openxmlformats-officedocument.presentationml.presentation" &&
            doc.ContentType != "text/plain" &&
            doc.ContentType != "application/pdf"&&
            doc.ContentType != "application/octet-stream" &&
            doc.ContentType != "application/x-zip-compressed"
            )
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
