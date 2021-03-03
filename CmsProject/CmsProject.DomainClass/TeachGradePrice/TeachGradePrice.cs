using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.TeachGradePrice
{
    /// <summary>
    /// موجودیت محاسبه مبلغ استاد
    /// </summary>
    public class TeachGradePrice
    {
        public TeachGradePrice()
        { }

        [Key]
        public int ID { get; set; }
    }
}