using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebCoffee.Services
{
    public class FileService
    {
        public async Task CreateFile(string path, string fileName, IFormFile photo, IWebHostEnvironment hostEnvironment)
        {
            using (var fs = new FileStream(hostEnvironment.WebRootPath + path + fileName, FileMode.Create))
            {
                await photo.CopyToAsync(fs);
            }
        }
    }
}
