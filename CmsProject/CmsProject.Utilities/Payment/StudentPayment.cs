using System;
using System.Linq;

namespace CmsProject.Utilities.Payment
{
    public static class StudentPayment
    {
        /// <summary>
        /// متد تولید شناسه واریز براساس شماره دانشجو
        /// </summary>
        /// <param name="studentNo">شماره دانشجو</param>
        /// <returns>شناسه واریز</returns>
        public static string GetPayment(string studentNo)
        {
            studentNo = string.Format("{0:000000000000000}", long.Parse(studentNo));
            int[] nums = { 15, 14, 13, 12, 11, 10, 9, 1, 2, 3, 4, 5, 6, 7, 8 };
            var counter = 0;
            var rowsum = 0;
            studentNo.ToList().ForEach(fn =>
            {
                var sum = (int.Parse(fn.ToString()) * nums[counter]);
                rowsum = rowsum + sum;
                counter++;
            }); ;
            rowsum = rowsum % 99;
            return Convert.ToInt64((studentNo + string.Format("{0:00}", rowsum))).ToString();
        }
    }
}