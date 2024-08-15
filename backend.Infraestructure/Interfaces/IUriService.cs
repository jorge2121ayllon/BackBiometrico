using backend.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Interfaces
{
    public interface IUriService
    {
        Uri GetPaginationUri(PostQueryFilter filter, string actionUrl);

    }
}
