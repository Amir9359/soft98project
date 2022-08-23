using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace soft98.Core.ViewModels
{
   public class ActiveViewModel
    {
        [Display(Name ="کد فعالسازی")]
        [MaxLength(6,ErrorMessage ="مقدار {0}  نمی تواند بیشتر از {1} باشد")]
        public string Code { get; set; }
    }
}
