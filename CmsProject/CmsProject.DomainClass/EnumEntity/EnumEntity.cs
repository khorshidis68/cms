using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.EnumEntity
{
    /// <summary>
    /// موجودیت مقادیر شمارشی - اینام
    /// </summary>
    public class EnumEntity
    {
        public EnumEntity()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "گروه مقادیر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string GroupEnumEn { get; set; }

        [Display(Name = "عنوان مقادیر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string Title { get; set; }

        [Display(Name = "مقدار مرتب سازی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Value { get; set; }
    }
}