using System;

namespace DotNetWebApiPaginationHateoas.Dtos
{
    public record GetHobbyResponseDto
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public DateTime CreatedAt { get; init; }
    }
}