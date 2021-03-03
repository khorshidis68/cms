using CmsProject.Utilities.EnumObject;
using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.HamavaInfo
{
    /// <summary>
    /// موچودیت اطلاعات هماوا
    /// </summary>
    public class HamavaInfo
    {
        public HamavaInfo()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "سال ورود")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int EnterYear { get; set; }

        [Display(Name = "زمان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TimeOf { get; set; }

        [Display(Name = "کد درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string LessonCode { get; set; }

        [Display(Name = "وضعیت درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int LessonStatus { get; set; }

        [Display(Name = "شناسه استاد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int? TeacherId { get; set; }

        [Display(Name = "کدملی استاد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string TeacherNationCode { get; set; }

        [Display(Name = "نام استاد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string TeacherName { get; set; }

        [Display(Name = "ActionNumber")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int ActionNumber { get; set; }

        [Display(Name = "کد مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string TrainingCenterCode { get; set; }

        [Display(Name = "تعداد دانشجو")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int StudentCount { get; set; } = 0;

        [Display(Name = "AllowStudentCount")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int AllowStudentCount { get; set; } = 0;

        [Display(Name = "AcceptTeacherId")]
        public int? AcceptTeacherId { get; set; }

        [Display(Name = "IsAcceptTeacher")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public bool IsAcceptTeacher { get; set; } = false;

        [Display(Name = "NumberOfQuestions")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int NumberOfQuestions { get; set; } = 0;

        [Display(Name = "مرکز")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public eHamavaStatus HStatus { get; set; } = eHamavaStatus.Import;
    }
}