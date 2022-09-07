using System.ComponentModel.DataAnnotations;

namespace soft98.DataAccessLayer.Entities
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "موضوع")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(200,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Subject { get; set; }

        [Display(Name = "پیام")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [DataType(dataType:DataType.MultilineText)]
        public string Description { get; set; }
    }
}