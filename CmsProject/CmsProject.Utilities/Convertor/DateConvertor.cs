using System;
using System.Globalization;

namespace CmsProject.Utilities.Convertor
{
    public static class DateConvertor
    {
        public static string ToShamsi(this DateTime miladiDate)
        {
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}",
                pc.GetYear(miladiDate),
                pc.GetMonth(miladiDate).ToString("00"),
                pc.GetDayOfMonth(miladiDate).ToString("00")
                );
        }
    }
}