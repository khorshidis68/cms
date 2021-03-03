using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.Grade
{
    /// <summary>
    /// موجودیت مقطع تحصیلی
    /// </summary>
    public class Grade
    {
        public Grade()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان مقطع تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Name { get; set; }

        [Display(Name = "مبلغ مقطع تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public decimal DefualtPay { get; set; }

        [Display(Name = "شناسه والد")]
        public int? ParentId { get; set; }
    }
}