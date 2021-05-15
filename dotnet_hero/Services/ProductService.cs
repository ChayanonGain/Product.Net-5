using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_hero.Data;
using dotnet_hero.Entities;
using dotnet_hero.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace dotnet_hero.Services
{
    public class ProductService : IProductService
    {
        private readonly DatabaseContext databaseContext;
        private readonly IUploadFileService uploadFileService;
        public ProductService(DatabaseContext databaseContext, IUploadFileService uploadFileService)
        {
            this.uploadFileService = uploadFileService;
            this.databaseContext = databaseContext;
        }
        public async Task<List<Product>> GetAllProduct()
        {
            return await databaseContext.Products.Include(p => p.Category).OrderByDescending(p => p.ProductId).ToListAsync();
        }
        public async Task<Product> GetProductByID(int id)
        {
            return await databaseContext.Products.Include(p => p.Category).Where(p => p.ProductId == id).FirstOrDefaultAsync();

        }
        public async Task Create(Product product)
        {
            databaseContext.Products.Add(product);
            await databaseContext.SaveChangesAsync();
        }
        public async Task Update(Product product)
        {
            databaseContext.Products.Update(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task Delete(Product product)
        {
            databaseContext.Remove(product);
            await databaseContext.SaveChangesAsync();
        }

        public async Task<(string errorMessage, string imageName)> UploadImage(List<IFormFile> formFile)
        {
            string errorMessage = String.Empty;
            string imageName = String.Empty;

            if(uploadFileService.IsUpload(formFile)) //เช็คว่า file มีการอัพโหลดเข้ามาหรือไม่ ต้อง return true
            {
                errorMessage = uploadFileService.Validation(formFile); //ถ้ามีการ Upload Function นี้จะใช้ในการในการ validate ว่าค่าที่ส่งกลับมามีค่า errorMessage ไหม
                if(String.IsNullOrEmpty(errorMessage)) //ถ้าค่า errorMessage เป็นว่าจะได้ค่าเป็น true แล้วทำเงื่อนไขตมบรรทัดล่าง
                {
                    imageName = (await uploadFileService.UploadImages(formFile))[0]; // [0] คือการยกตัวอย่าง case ว่าถ้าเป็นภาพเดียวจะได้คิอแค่ index แรก
                }
            }

            return (errorMessage , imageName);// Return แต่ละค่าคือ ไม่ errorMessage ก็ Retrun ImageName ไปบันทึกต่อใน DataBase

        }
    }
}