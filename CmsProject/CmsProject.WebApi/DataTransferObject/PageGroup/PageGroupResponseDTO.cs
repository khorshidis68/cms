namespace CmsProject.WebApi.DataTransferObject.PageGroup
{
    public class PageGroupResponseDTO
    {
        /// <summary>
        /// عنوان گروه خبری
        /// </summary>
        public string TitlePageGroup { get; set; }
        /// <summary>
        /// تعداد اخبار گروه خبری
        /// </summary>
        public int CountPage { get; set; }
    }
}