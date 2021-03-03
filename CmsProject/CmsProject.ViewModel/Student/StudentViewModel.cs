using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Student
{
    /// <summary>
    /// موجودیت دانشجو
    /// </summary>
    public class StudentViewModel
    {
        [Key]
        public int ID { get; set; }
        
        [Display(Name = "شناسه مقطع تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Grade { get; set; }

        [Display(Name = "Quotas")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 150)]
        public string Quotas { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TimeOf { get; set; }

        [Display(Name = "سال ورود")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int EnterYear { get; set; }

        [Display(Name = "آدرس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 500)]
        public string Address { get; internal set; }

        [Display(Name = "نام مرکز آموزش")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string TrainingCenterName { get; set; }

        [Display(Name = "کد مرکز آموزش")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string TrainingCenterCode { get; set; }

        [Display(Name = "تلفن")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Tel { get; set; }

        [Display(Name = "StudyGroup")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string StudyGroup { get; set; }

        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 150)]
        public long StudentNo { get; set; }

        [Display(Name = "DurationType")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string DurationType { get; set; }

        [Display(Name = "AvargeNumber")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public decimal AvargeNumber { get; set; }

        [Display(Name = "شناسه رشته تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Major { get; set; }

        [Display(Name = "عنوان رشته تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string MajorStr { get; set; }
    }
}