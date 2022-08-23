using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace soft98.DataAccessLayer.Entities
{
     public class Category
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "نام دسته")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(20, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Name { get; set; }

        [ForeignKey("Parent")]
        [Display(Name = "نام سردسته")]
        public int? ParentId { get; set; }
        public virtual Category Parent { get; set; }
    }
}
