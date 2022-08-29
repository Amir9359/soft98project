using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace soft98.DataAccessLayer.Entities
{
  public class Product
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام نرم افزار")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(20,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Name { get; set; }

        [Display(Name = "توضیحات")]
        [DataType(dataType:DataType.MultilineText)]
        public string Description { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "انتخاب تصویر")]
        [NotMapped]
        public IFormFile PicFile { get; set; }

        [NotMapped]
        public string PicAddress { get; set; }

        [Display(Name = "تصویر شاخص")]
        [MaxLength(100, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string PicName { get; set; }

        [Display(Name = "تاریخ آخرین بروزرسانی")]
        [MaxLength(23,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string UpdateDate { get; set; }

        [Display(Name = "راهنمای نصب")]
        [DataType(dataType:DataType.MultilineText)]
        public string InstallDescription { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int? SeenCount { get; set; }

        [Display(Name = "نام سردسته")]
        [ForeignKey("CategoryId")]
        public virtual  Category Category { get; set; }

    }
}
