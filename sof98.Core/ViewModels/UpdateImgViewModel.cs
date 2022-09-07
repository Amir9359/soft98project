using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace soft98.Core.ViewModels
{
   public class UpdateImgViewModel
    {

        [Display(Name = "انتخاب تصویر")]
  
        public IFormFile PicFile { get; set; }

        [NotMapped]
        public string PicAddress { get; set; }


        [Display(Name = "لینک بنر")]
        public string Link { get; set; }

    }
}
