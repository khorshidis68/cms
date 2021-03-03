namespace CmsProject.ViewModel.Page
{
    public class ShowGroupsViewModel
    {
        public int ID { get; set; }

        /// <summary>
        /// عنوان گروه خبری
        /// </summary>
        public string GroupTitle { get; set; }

        /// <summary>
        /// تعداد اخبار
        /// </summary>
        public int PageCount { get; set; }
    }
}