using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.BankReport
{
    /// <summary>
    /// موجودیت گزارش بانک
    /// </summary>
    public class BankReport
    {
        public BankReport()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "تاریخ")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string DateOf { get; set; }

        [Display(Name = "زمان")]
        [MaxLength(length: 50)]
        public string TimeOf { get; set; }

        [Display(Name = "شعبه")]
        [MaxLength(length: 500)]
        public string Branch { get; set; }

        [Display(Name = "کدشعبه")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int BranchCode { get; set; }

        [Display(Name = "توضیحات")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 2000)]
        public string Discription { get; set; }

        [Display(Name = "نام بستانکار")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 50)]
        public string CreditorName { get; set; }

        [Display(Name = "شماره واریز")]
        public long? PaymentNo { get; set; }

        [Display(Name = "شواهد و مدارک")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int Evidenc { get; set; }

        [Display(Name = "بدهکار یا بستانکار")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public long DebtorORCreditor { get; set; }
    }
}