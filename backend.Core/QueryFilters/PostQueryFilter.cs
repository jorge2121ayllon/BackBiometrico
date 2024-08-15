using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Core.QueryFilters
{
    public class PostQueryFilter
    {

        public string? filter { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
