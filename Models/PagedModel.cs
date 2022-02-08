using System.Collections.Generic;

namespace DotNetWebApiPaginationHateoas.Models
{
    public class PagedModel<TModel>
    {
        const int MaxPageSize = 500;

        private int _pageSize;
        // Results per page
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        // Current page number
        public int CurrentPage { get; set; }

        // Total number of results
        public int TotalItems { get; set; }

        // Total number of pages
        public int TotalPages { get; set; }
        
        public IList<TModel> Data { get; set; }

        public PagedModel()
        {
            Data = new List<TModel>();
        }
    }
}