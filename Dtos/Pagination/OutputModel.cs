namespace ComplaintSystem.Dtos.Pagination
{
    public class OutputModel<T> where T : class
    {
        public PagingHeader Paging { get; set; }
        public List<LinkInfo> Links { get; set; }
        public List<T> Items { get; set; }
    }
}
