using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using dotnet_hero.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace dotnet_hero.Services
{
    public class UploadFileService : IUploadFileService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;
        public UploadFileService(IWebHostEnvironment webHostEnvironment, IConfiguration configuration) //IWebhost ไว้ใช้เข้าถึงโฟลเดอร์ที่เก็บไฟล์ , Iconfigure ใช้เข้าถึง setting ที่เรากำหนด
        {
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        public bool IsUpload(List<IFormFile> formFile) => formFile != null && formFile.Sum(f => f.Length) > 0; //เช็คว่า Size เกินกว่าที่กำหนดหรือเปล่า

        public string Validation(List<IFormFile> formFile)
        {
            foreach (var formfile in formFile)   //Foreach มาแกะที่ละไฟล์ เพื่อเช็คว่าแต่ละไฟลฺ์มี นามกสุล และ ขนาด ตามที่ตอ้งการหรือไม่ ถ้าถูกต้อง return null;
            {
                if(!ValidationExtension(formfile.FileName))
                {
                    return "Invalid File Extension"; //return ข้อความ
                }

                if(!ValidationSize(formfile.Length))
                {
                    return "The File To Large";
                }
            }

            return null;

        }

        public async Task<List<string>> UploadImages(List<IFormFile> formFile)
        {
            List<string> listFileName = new List<string>();
            string UploadPath = $"{webHostEnvironment.WebRootPath}/images";

            foreach (var formfile in formFile)
            {
                string FileName = Guid.NewGuid().ToString() + Path.GetExtension(formfile.FileName);
                string FullPath = UploadPath + FileName;
                using (var stream = File.Create(FullPath))
                {  
                    await formfile.CopyToAsync(stream);
                }

                listFileName.Add(FileName);
            }

            return listFileName;
        }

        public bool ValidationExtension(string FileName) //เป็นการเช็คนามสกุลไฟล์
        {
            string[] PermittedExtension = {".jpg",".png"};
            var ext = Path.GetExtension(FileName).ToLowerInvariant();
            if(String.IsNullOrEmpty(ext) || !PermittedExtension.Contains(ext))
            {
                return false;
            }
            return true;
        }

        public bool ValidationSize(long FileSize) => configuration.GetValue<long>("FileSizeLimit") > FileSize; // เป็น Method เช็คขนาดไฟล์ return true;

    }
}