using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Person
{
    /// <summary>
    /// موجودیت شخص
    /// </summary>
    public class PersonViewModel
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "نام")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 150)]
        public string Name { get; set; }

        [Display(Name = "فامیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 150)]
        public string LName { get; set; }

        [Display(Name = "نام پدر")]
        [MaxLength(length: 150)]
        public string FName { get; set; }

        [Display(Name = "کدملی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 11)]
        public string NationCode { get; set; }

        [Display(Name = "تاریخ تولد")]
        [MaxLength(length: 11)]
        public string BirthDate { get; set; }

        [Display(Name = "شماره شناسنامه")]
        [MaxLength(length: 11)]
        public string IdNo { get; set; }

        [Display(Name = "موبایل")]
        [MaxLength(length: 11)]
        public string Mobile { get; set; }

        [Display(Name = "شناسه واریز")]
        [MaxLength(length: 50)]
        public string DefaultPaymentId { get; set; }

        [Display(Name = "نام و فامیلی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 300)]
        public string FullName { get; set; }

        [Display(Name = "جنسیت")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Gender { get; set; }

        [Display(Name = "جنسیت")]
        public string GenderStr { get { return Gender == 1 ? "مرد" : Gender == 2 ? "زن" : "نامشخص"; } }
    }
}