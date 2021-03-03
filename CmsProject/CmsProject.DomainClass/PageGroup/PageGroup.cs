using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainModelClass.PageGroup
{
    /// <summary>
    /// موجودیت گروه خبری
    /// </summary>
    public class PageGroup
    {
        public PageGroup()
        {
        }

        [Key]
        public int ID { get; set; }
        
        [Display(Name ="عنوان گروه خبری")]
        [Required(ErrorMessage ="وارد کردن {0} اجباری است")]
        [MaxLength(length:200)]
        public string GroupTitle { get; set; }

        public virtual List<Page.Page> Pages { get; set; }
    }
}