

using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetWebApiPaginationHateoas.Data;
using DotNetWebApiPaginationHateoas.Dtos;
using DotNetWebApiPaginationHateoas.Interfaces;
using DotNetWebApiPaginationHateoas.Extensions;


namespace DotNetWebApiPaginationHateoas.Services
{
    public class HobbyService: IHobbyService
    { 
        private readonly HobbyDbContext _dbContext;
        public HobbyService(HobbyDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetHobbyListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken)
        {

            var hobbies = await _dbContext.Hobbies
                           .AsNoTracking()
                           .OrderBy(p => p.CreatedAt)
                           .PaginateAsync(page, limit, cancellationToken);

            return new GetHobbyListResponseDto {
                CurrentPage = hobbies.CurrentPage,
                TotalPages = hobbies.TotalPages,
                TotalItems = hobbies.TotalItems,
                Items = hobbies.Data.Select(p => new GetHobbyResponseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    CreatedAt = p.CreatedAt
                }).ToList()
            };
        }
    }
}