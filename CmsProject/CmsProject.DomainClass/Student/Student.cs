using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.Student
{
    /// <summary>
    /// موجودیت دانشجو
    /// </summary>
    public class Student
    {
        public Student()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 150)]
        public long StudentNo { get; set; }

        [Display(Name = "شناسه واریز")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public long PaymentNo { get; set; }

        [Display(Name = "شناسه رشته تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Major { get; set; }

        [Display(Name = "شناسه مقطع تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Grade { get; set; }

        [Display(Name = "Quotas")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 150)]
        public string Quotas { get; set; }

        [Display(Name = "TimeOf")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TimeOf { get; set; }

        [Display(Name = "سال ورود")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int EnterYear { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 20)]
        public string NationCode { get; set; }

        [Display(Name = "شناسه شخص")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int PersonId { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 500)]
        public string Address { get; set; }

        [Display(Name = "کد مرکز آموزش")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string TrainingCenterCode { get; set; }

        [Display(Name = "شناسه مرکز آموزش")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TrainingCenterId { get; set; }

        [Display(Name = "موبایل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Mobile { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Tel { get; set; }

        [Display(Name = "StudyGroup")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string StudyGroup { get; set; }

        [Display(Name = "DurationType")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string DurationType { get; set; }

        [Display(Name = "AvargeNumber")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public decimal AvargeNumber { get; set; }
    }
}