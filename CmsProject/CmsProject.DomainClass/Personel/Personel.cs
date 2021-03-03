using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.Personel
{
    /// <summary>
    /// موجودیت پرسنل
    /// </summary>
    public class Personel
    {
        public Personel()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int PersonCode { get; set; }

        [Display(Name = "شناسه مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TrainingCenterId { get; set; }

        [Display(Name = "شناسه پرسنل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int PersonId { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 11)]
        public string NationCode { get; set; }
    }
}