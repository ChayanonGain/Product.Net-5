using System.Collections.Generic;
using System.Threading.Tasks;
using dotnet_hero.Entities;
using Microsoft.AspNetCore.Http;

namespace dotnet_hero.Interfaces
{
    public interface IProductService
    {
         Task<List<Product>> GetAllProduct();
         Task<Product> GetProductByID(int id);
         Task Create(Product product);
         Task Update(Product product);
         Task Delete(Product product);

         Task<(string errorMessage, string imageName)> UploadImage(List<IFormFile> formFile);
    }
}