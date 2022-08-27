using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace soft98.DataAccessLayer.Entities
{
    public class Banner
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "کد جایگاه")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(20,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string PlaceCode { get; set; }

        [Display(Name = "شرح بنر")]
        [DataType(dataType:DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = " قیمت بنر")]
        public int Price { get; set; }

        [Display(Name = "فعال/غیر فعال")]
        public bool IsActive { get; set; }
        public virtual ICollection<BannerFactor> BannerFactors { get; set; }
    }
}
