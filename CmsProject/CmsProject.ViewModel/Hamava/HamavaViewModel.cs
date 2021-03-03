using CmsProject.Utilities.EnumObject;
using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Hamava
{
    /// <summary>
    /// موچودیت اطلاعات هماوا
    /// </summary>
    public class HamavaViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "مرکز")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public eHamavaStatus HStatus { get; set; }

        [Display(Name = "عنوان مرکز")]
        public string HStatusStr { get { return HStatus.TitleEnum<eHamavaStatus>(); } }

        [Display(Name = "IsTeacherFind")]
        public string IsTeacherFind { get; set; } = "نیست";

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

        [Display(Name = "نام درس")]
        public string LessonName { get; set; }

        [Display(Name = "وضعیت درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public string LessonStatus { get; set; }

        [Display(Name = "نوع درس")]
        [MaxLength(length: 200)]
        public string LessonType { get; set; }

        [Display(Name = "شماره استاد")]
        [MaxLength(length: 200)]
        public string TeacherNo { get; set; }

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

        [Display(Name = "نام مرکز آموزشی")]
        public string TrainingCenterName { get; set; }

        [Display(Name = "تعداد دانشجو")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int StudentCount { get; set; } = 0;

        [Display(Name = "AllowStudentCount")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int AllowStudentCount { get; set; } = 0;

        [Display(Name = "AcceptTeacherNo")]
        public int? AcceptTeacherNo { get; set; }

        [Display(Name = "کدملی استاد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string AcceptTeacherNationCode { get; set; }

        [Display(Name = "نام استاد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string AcceptTeacherName { get; set; }

        [Display(Name = "IsAcceptTeacher")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public bool IsAcceptTeacher { get; set; } = false;

        [Display(Name = "NumberOfQuestions")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int NumberOfQuestions { get; set; } = 0;
        
        
        public int TrainingCenterId { get; set; }
    }
}