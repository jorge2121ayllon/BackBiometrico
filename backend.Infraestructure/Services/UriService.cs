using backend.Core.QueryFilters;
using backend.Infraestructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace backend.Infraestructure.Services
{
    public class UriService : IUriService
    {
        private readonly string _baseUri;

        public UriService(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetPaginationUri(PostQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }


    }
}
