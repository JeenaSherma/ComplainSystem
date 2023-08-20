namespace ComplaintSystem.Dtos.Pagination
{
    public class PagedResponse<T>
    {
        public PagedResponse(PagedListDto<T> data, List<LinkInfo> links)
        {
            Data = data;
            Links = links;
        }

        public PagedListDto<T> Data { get; set; }
        public List<LinkInfo> Links { get; set; }
    }
}