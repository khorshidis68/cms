using System.ComponentModel.DataAnnotations;

namespace CmsProject.ViewModel.ManageRole
{
    public class IndexRoleViewModel
    {
        public string Id { get; set; }

        [Required]
        [Display(Name = "نام گروه")]
        public string RoleName { get; set; }
    }
}