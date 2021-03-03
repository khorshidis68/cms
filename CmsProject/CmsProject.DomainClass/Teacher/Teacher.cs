using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.Teacher
{
    /// <summary>
    ///  موجودیت استاد
    /// </summary>
    public class Teacher
    {
        public Teacher()
        { }

        [Key]
        public int ID { get; set; }

        [Display(Name = "شناسه پرسنل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public int PersonId { get; set; }

        [Display(Name = "شماره استاد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string TeachNo { get; set; }

        [Display(Name = "شماره حساب")]
        public long? AccountNo { get; set; }

        [Display(Name = "نام بانک")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string BankName { get; set; }

        [Display(Name = "مقطع تحصیلی پیش فرض")]
        public int? DefualtGrade { get; set; }

        [Display(Name = "شناسه مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TrainingCenterId { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string NationCode { get; internal set; }

        [Display(Name = "کد مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string TrainingCenterCode { get; internal set; }
    }
}