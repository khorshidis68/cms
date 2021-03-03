using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.Lesson
{
    /// <summary>
    /// موجودیت درس
    /// </summary>
    public class Lesson
    {
        public Lesson()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 500)]
        public string Title { get; set; }

        [Display(Name = "کد درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Code { get; set; }

        [Display(Name = "نوع درس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 500)]
        public string LessonType { get; set; }

        [Display(Name = "کد نوع درس")]
        public int? LessonTypeCode { get; set; }
        
    }
}