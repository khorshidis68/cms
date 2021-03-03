namespace CmsProject.WebApi.Models.BaseModel
{
    public class RequestBase
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RequestBase<T> : RequestBase
    {
        public T RequestPayload { get; set; }
    }
}