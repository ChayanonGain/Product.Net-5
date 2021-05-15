using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace dotnet_hero.DTOs.Product
{
    public class ProductRequest
    {
        public int? ProductId { get; set; }

        [Required(ErrorMessage = "กรุณากรอกชื่อสินค้า")]
        [Display(Name = "ชื่อสินค้า")]
        public string Name { get; set; }

        [Range(0,1_000_0)]
        public int Stock { get; set; }

        [Required]
        [Range(0,1_000_000)]
        [Display(Name = "ชื่อสินค้า")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "กรุณาเลือกประเภทสินค้า")]
        [Display(Name = "ประเภทสินค้า")]
        public int CategoryId { get; set; }
        public List<IFormFile> FormFile {get;set;}
    }
}