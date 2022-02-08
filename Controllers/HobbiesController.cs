

using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using DotNetWebApiPaginationHateoas.Dtos;
using DotNetWebApiPaginationHateoas.Interfaces;


namespace DotNetWebApiPaginationHateoas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HobbiesController : ControllerBase
    {
        private readonly IHobbyService _service;

        public HobbiesController(IHobbyService service)
        {
            _service = service;
        }

        [HttpGet(Name = nameof(GetHobbyListAsync))]
        [ProducesResponseType(typeof(GetHobbyListResponseDto), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetHobbyListAsync(
            [FromQuery] UrlQueryParameters urlQueryParameters,
            CancellationToken cancellationToken)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var hobbies = await _service.GetByPageAsync(
                                    urlQueryParameters.Limit,
                                    urlQueryParameters.Page,
                                    cancellationToken);

            return Ok(hobbies);
        }

    }

    public record UrlQueryParameters(int Limit = 50, int Page = 1);
}