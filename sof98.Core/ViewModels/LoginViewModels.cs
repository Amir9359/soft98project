using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace soft98.Core.ViewModels
{
    public class LoginViewModels
    {
        [DisplayName("شماره موبایل")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(11,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Phone { get; set; }

        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        [DataType(DataType.Password)] 
        public string Password { get; set; }
    }
}
