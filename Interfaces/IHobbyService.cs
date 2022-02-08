

using System.Threading;
using System.Threading.Tasks;
using DotNetWebApiPaginationHateoas.Dtos;

namespace DotNetWebApiPaginationHateoas.Interfaces
{
    public interface IHobbyService
    {
        Task<GetHobbyListResponseDto> GetByPageAsync(int limit, int page, CancellationToken cancellationToken);
    }
}