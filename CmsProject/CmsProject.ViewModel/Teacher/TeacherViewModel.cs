using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Teacher
{
    /// <summary>
    ///  موجودیت استاد
    /// </summary>
    public class TeacherViewModel
    {
        [Key]
        public int ID { get; set; }

        public int TeacherId { get; set; }

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

        [Display(Name = "عنوان مقطع تحصیلی پیش فرض")]
        public string DefualtGradeStr { get; set; }

        [Display(Name = "عنوان مرکز آموزشی")]
        public string TrainingCenterName { get; set; }

        [Display(Name = "شناسه مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TrainingCenterId { get; }

        [Display(Name = "کد مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string TrainingCenterCode { get; internal set; }
    }
}