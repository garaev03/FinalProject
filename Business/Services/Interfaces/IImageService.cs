using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services.Interfaces
{
    public interface IImageService
    {
        void CheckType(IFormFile formFile);
        void CheckSize(IFormFile formFile, int size);
        Task<string> CreateFileAsync(string Folderpath,IFormFile formFile);
    }
}
