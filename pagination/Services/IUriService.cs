using Pagination.Filter;
using System;

namespace Pagination.Services
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
