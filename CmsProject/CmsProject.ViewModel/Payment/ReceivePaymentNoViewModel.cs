using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Payment
{
    public class ReceivePaymentNoViewModel
    {
        /// <summary>
        /// شماره دانشجویی
        /// </summary>
        [Display(Name = "شماره دانشجویی")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        public string StudentNo { get; set; }
    }
}