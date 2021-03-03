using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Personel
{
    /// <summary>
    /// موجودیت پرسنل
    /// </summary>
    public class PersonelViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "کد پرسنلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public int PersonCode { get; set; }

        [Display(Name = "شناسه مرکز آموزشی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int TrainingCenterId { get; set; }
        
        [Display(Name = "شناسه مرکز آموزشی")]
        public string TrainingCenterStr { get; set; }

        [Display(Name = "کد مرکز آموزشی")]
        public string TrainingCenterCode { get; set; }

        [Display(Name = "شناسه پرسنل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int PersonId { get; set; }

        [Display(Name = "شناسه پرسنل")]
        public string PersonFullName { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 11)]
        public string NationCode { get; set; }
    }
}