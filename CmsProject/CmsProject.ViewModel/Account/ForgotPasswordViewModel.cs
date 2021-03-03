using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.Account
{
    public class ForgotPasswordViewModel
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمایید")]
        [EmailAddress]
        public string Email { get; set; }
    }
}