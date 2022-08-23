using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace soft98.DataAccessLayer.Entities
{
    public class Role
    {
        [Key]
        public int Id { get; set; }
        [DisplayName("نام نقش")]
        [Required(ErrorMessage = "مقدار {0} را وارد کنید ")]
        [MaxLength(20,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string Name { get; set; }

        public virtual ICollection<User>  Users{ get; set; }

    }
}