using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace soft98.Core.ViewModels
{
   public class ForgetViewModel
    {
        [Display(Name ="شماره تماس")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(11,ErrorMessage ="مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Phone { get; set; }
    }
}
