using Microsoft.AspNetCore.Authentication.OAuth;
using System.IO;

namespace WebApplication1d.Helpers
{
    public static class FileUploadExtension
    {
        public static async Task<string> fileupload(this IFormFile file, string path)
        {
            string filename = file.FileName.Length > 32 ?
                file.FileName.Substring(file.FileName.Length-32) :
                file.FileName;
            filename = Path.Combine(path,Path.GetRandomFileName()+filename);

            using (FileStream fs =  File.Create(Path.Combine(PathConst.roothpath, filename)))
            {
                file.CopyTo(fs);
            }
            return filename;
           
        }
    }
}