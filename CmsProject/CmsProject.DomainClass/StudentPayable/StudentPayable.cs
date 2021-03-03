using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.StudentPayable
{
    /// <summary>
    /// موجودیت پرداختی دانشجویان
    /// </summary>
    public class StudentPayable
    {
        public StudentPayable()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "سال ورود")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int EnterYear { get; set; }

        [Display(Name = "EnterPaymet")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int EnterPaymet { get; set; }

        [Display(Name = "مبلغ پرداختی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public long Payable { get; set; }

        [Display(Name = "شناسه پرداخت")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public long PaymentNo { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public long StudentNo { get; set; }
    }
}