using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Study
{
    public class StudyViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "کد دروس مطالعه")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Code { get; set; }

        [Display(Name = "عنوان دروس مطالعه")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string Name { get; set; }

        [Display(Name = "ساعت نظری")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TheoreticalHour { get; set; }

        [Display(Name = "ساعت عملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int PracticalHour { get; set; }

        [Display(Name = "حساب نظری")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TheoreticalCount { get; set; }

        [Display(Name = "تعداد عملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int PracticalCount { get; set; }

        [Display(Name = "نوع درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string LessonType { get; set; }

        [Display(Name = "کد نوع درس")]
        public int? LessonTypeCode { get; set; }

        [Display(Name = "شناسه مقطع تحصیلی")]
        public int? GradeId { get; set; }

        [Display(Name = "مقطع تحصیلی")]
        public string GradeStr { get; set; }
    }
}