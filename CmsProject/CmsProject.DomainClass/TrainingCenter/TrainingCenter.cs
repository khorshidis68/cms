using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.TrainingCenter
{
    /// <summary>
    /// موجودیت مرکز آموزشی
    /// </summary>
    public class TrainingCenter
    {
        public TrainingCenter()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "عنوان مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Name { get; set; }

        [Display(Name = "کد مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string Code { get; set; }
    }
}