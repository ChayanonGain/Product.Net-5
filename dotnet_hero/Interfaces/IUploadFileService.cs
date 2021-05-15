using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace dotnet_hero.Interfaces
{
    public interface IUploadFileService
    {
        bool IsUpload(List<IFormFile> formFile);
        string Validation(List<IFormFile> formFile);
        Task<List<string>> UploadImages(List<IFormFile> formFile);
    }
}