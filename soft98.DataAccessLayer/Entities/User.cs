using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace soft98.DataAccessLayer.Entities
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("شماره تلفن")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید. ")]
        [MaxLength(11, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Phone { get; set; }
        public int RoleId { get; set; }

        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید. ")]
        [MaxLength(50, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Password { get; set; }

        [DisplayName("کد فعال ساز")]
        [MaxLength(6, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string Code { get; set; }

        [DisplayName("فعال /غیر فعال")]
        public bool IsActive { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }
    }
}