using System.Collections.Generic;
using DotNetWebApiPaginationHateoas.Extensions;

namespace DotNetWebApiPaginationHateoas.Interfaces
{
    public interface ILinkedResource
    {
        public IDictionary<LinkedResourceType, LinkedResource> Links { get; set; }
    }
}