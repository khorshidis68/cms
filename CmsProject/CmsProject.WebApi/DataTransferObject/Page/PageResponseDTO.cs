namespace CmsProject.WebApi.DataTransferObject
{
    public class PageResponseDTO
    {
        /// <summary>
        /// عنوان خبر
        /// </summary>
        public string pageTitle { get; set; }
        /// <summary>
        /// توضیح مختصر خبر
        /// </summary>
        public string shortDescription { get; set; }
        /// <summary>
        /// متن کامل خبر
        /// </summary>
        public string pageText { get; set; }
    }
}