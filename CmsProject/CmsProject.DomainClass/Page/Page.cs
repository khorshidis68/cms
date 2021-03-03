using System;
using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainModelClass.Page
{
    /// <summary>
    /// موجودیت خبر
    /// </summary>
    public class Page
    {
        public Page()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "گروه خبر")]
        public int PageGroupID { get; set; }

        [Display(Name = "عنوان خبر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string PageTitle { get; set; }

        [Display(Name = "توضیح مختصر")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        [DataType(DataType.MultilineText)]
        public string ShortDescription { get; set; }

        [Display(Name = "متن کامل")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        [DataType(DataType.MultilineText)]
        public string PageText { get; set; }

        [Display(Name = "بازدید")]
        public int PageVisit { get; set; }

        [Display(Name = "تصویر")]
        public string ImageName { get; set; }

        [Display(Name = "کلمات کلیدی")]
        public string PageTags { get; set; }

        [Display(Name = "نمایش در اسلایدر")]
        public bool ShowInSlider { get; set; }

        [Display(Name = "تاریخ")]
        public DateTime CreateDate { get; set; }

        public virtual PageGroup.PageGroup PageGroup { get; set;}
    }
}