using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalSpawn.Domain.NavigationEntities
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }

        public bool HasPreviusPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
        public int NextPageNumber => HasNextPage ? CurrentPage + 1 : -1;
        public int PreviusPageNumber => HasPreviusPage ? CurrentPage - 1 : -1;

        public PagedList(IEnumerable<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            var pageCount = (double)TotalCount / pageSize;
            TotalPages = (int)Math.Ceiling(pageCount);
            AddRange(items);
        }   

        public static PagedList<T> Create(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var result = source;
            var rowsCount = result.Count();
            var currentPage = pageNumber;
            var takeRows = pageSize;
            int skipRows = (pageNumber - 1) * pageSize;
            var items = source.Skip(skipRows).Take(takeRows);
            return new PagedList<T>(items, rowsCount, currentPage, takeRows);
        }
    }
}
