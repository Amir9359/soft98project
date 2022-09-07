using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace soft98.DataAccessLayer.Entities
{
    public class BannerFactor
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BannerId { get; set; }

        [Display(Name = "تاریخ شروع اجاره بنر")]
        [MaxLength(40,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string RentDate { get; set; }

        [Display(Name = "تاریخ انقضا اجاره بنر")]
        [MaxLength(40, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string ExpireDate { get; set; }

        [Display(Name = "مبلغ سفارش")]
        public int PayPrice { get; set; }

        [Display(Name = "شماره سفارش")]
        [MaxLength(10, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string OrderNumber { get; set; }

        [Display(Name = "شماره پیگیری")]
        [MaxLength(15, ErrorMessage = "مقدار {0} نمیتواند بیشتر از {1} باشد")]
        public string FollowNumber { get; set; }

        [Display(Name = "منقضی شده")]
        public bool IsExpire { get; set; }

        [Display(Name = "تعداد بازدید")]
        public int? SeenNumber { get; set; }
      
        [Display(Name = "تصویر شاخص")]
        [MaxLength(100,ErrorMessage ="مقدار {0} نمیتواند بیشتر از {1} باشد" )]
        public string PicName { get; set; }

        [Display(Name = "لینک بنر")]
        public string PicLink { get; set; }

        [ForeignKey("BannerId")]
        public virtual Banner Banner { get; set; }


        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
