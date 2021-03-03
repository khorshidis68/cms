using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Major
{
    /// <summary>
    /// مدل نمایشی رشته تحصیلی
    /// </summary>
    public class MajorViewModel
    {
        public int ID { get; set; }

        [Display(Name = "عنوان رشته تحصیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 500)]
        public string Name { get; set; }

        [Display(Name = "شناسه مقطع تحصیلی")]
        public int? GradeId { get; set; }

        [Display(Name = "عنوان مقطع تحصیلی")]
        public string GradeStr { get; set; }
    }
}