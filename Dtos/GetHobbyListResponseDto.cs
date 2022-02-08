using System.Collections.Generic;
using DotNetWebApiPaginationHateoas.Extensions;
using DotNetWebApiPaginationHateoas.Interfaces;

namespace DotNetWebApiPaginationHateoas.Dtos
{
    public record GetHobbyListResponseDto : ILinkedResource
    {
        public int CurrentPage { get; init; }

        public int TotalItems { get; init; }

        public int TotalPages { get; init; }

        public List<GetHobbyResponseDto> Items { get; init; }

        public IDictionary<LinkedResourceType, LinkedResource> Links { get; set; }
    }
}