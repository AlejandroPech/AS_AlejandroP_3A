using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalSpawn.Domain.NavigationEntities
{
    public class Metadata
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviusPage { get; set; }
        public int FirstRowOnPage => ((CurrentPage - 1) * PageSize) + 1;
        public int LastRowOnPage => Math.Min(CurrentPage * PageSize, TotalCount);
    }
}
