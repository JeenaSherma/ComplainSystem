using Microsoft.AspNetCore.Mvc;

namespace ComplaintSystem.Dtos.Pagination
{
    public class PaginationHelper
    {
        //public static List<LinkInfo> GetLinks<T>(PagedListDto<T> pagedListDto, IUrlHelper urlHelper, string routeName) where T : class
        //{
        //    var links = new List<LinkInfo>();

        //    if (pagedListDto.HasPreviousPage)
        //    {
        //        links.Add(CreateLink(urlHelper, routeName, pagedListDto.PreviousPageNumber, pagedListDto.PageSize, "previousPage", "GET"));
        //    }

        //    links.Add(CreateLink(urlHelper, routeName, pagedListDto.PageNumber, pagedListDto.PageSize, "self", "GET"));

        //    if (pagedListDto.HasNextPage)
        //    {
        //        links.Add(CreateLink(urlHelper, routeName, pagedListDto.NextPageNumber, pagedListDto.PageSize, "nextPage", "GET"));
        //    }

        //    return links;
        //}
        public static List<LinkInfo> GetLinks<T>(PagedListDto<T> pagedListDto, IUrlHelper urlHelper, string routeName) where T : class
        {
            var links = new List<LinkInfo>();

            if (pagedListDto.HasPreviousPage)
            {
                links.Add(CreateLink(urlHelper, routeName, pagedListDto.PreviousPageNumber, pagedListDto.PageSize, "previousPage", "GET"));
            }

            links.Add(CreateLink(urlHelper, routeName, pagedListDto.PageNumber, pagedListDto.PageSize, "self", "GET"));

            if (pagedListDto.HasNextPage)
            {
                links.Add(CreateLink(urlHelper, routeName, pagedListDto.NextPageNumber, pagedListDto.PageSize, "nextPage", "GET"));
            }

            return links;
        }

        private static LinkInfo CreateLink(IUrlHelper urlHelper, string routeName, int pageNumber, int pageSize, string rel, string method)
        {
            return new LinkInfo
            {
                Href = urlHelper.Link(routeName, new { PageNumber = pageNumber, PageSize = pageSize }),
                Rel = rel,
                Method = method
            };
        }

    }
}
