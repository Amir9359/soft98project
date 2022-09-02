using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace soft98.DataAccessLayer.Entities
{
   public class ProductDownloadFile
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام نرم افزار")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(300, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Productlink { get; set; }
        public int ProductId { get; set; }

        [Display(Name = "انتخاب فایل")]
        [NotMapped]
        public IFormFile File { get; set; }

        [NotMapped]
        public string FileAddress { get; set; }

        [Display(Name = "فایل شاخص")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string FileName { get; set; }

        [Display(Name = "حجم دانلود ")]
        public string Volume { get; set; }

        [Display(Name = "تعداد دانلود ")]
        public int DownloadCount { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
