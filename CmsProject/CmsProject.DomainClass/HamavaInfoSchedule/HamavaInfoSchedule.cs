using System.ComponentModel.DataAnnotations;

namespace CmsProject.DomainClass.HamavaInfoSchedule
{
    /// <summary>
    /// موجودیت اطلاعات هماوا دانشگاه
    /// </summary>
    public class HamavaInfoSchedule
    {
        public HamavaInfoSchedule()
        {
        }

        [Key]
        public int ID { get; set; }

        [Display(Name = "HamavaInfoId")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        public int HamavaInfoId { get; set; }

        [Display(Name = "WeeklyScheduleDay")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string WeeklyScheduleDay { get; set; }

        [Display(Name = "WeeklyScheduleFromTime")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string WeeklyScheduleFromTime { get; set; }

        [Display(Name = "WeeklyScheduleToTime")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری است")]
        [MaxLength(length: 200)]
        public string WeeklyScheduleToTime { get; set; }
    }
}