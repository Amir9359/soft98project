using System.ComponentModel.DataAnnotations;
using Microsoft.VisualBasic;

namespace soft98.DataAccessLayer.Entities
{
    public class Matlab
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "عنوان مطلب ")]
        [MaxLength(100,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        public string Title { get; set; }

        [Display(Name = "شرح مطلب")]
        [DataType(dataType:DataType.MultilineText)]
        public string Description { get; set; }

        [Display(Name = "تاریخ ثبت")]
        [MaxLength(23,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Date { get; set; }

        [Display(Name = "نمایش یا عدم نمایش")]
        public bool Show { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int? NumberSeen { get; set; }

        [Display(Name = "نوع نرم افزار ")]
        public bool IsSoft { get; set; }

        [Display(Name = " نوع موبایل ")]
        public bool IsMobile { get; set; }

        [Display(Name = "نوع تکنولوژی ")]
        public bool IsTech { get; set; }
    }
}