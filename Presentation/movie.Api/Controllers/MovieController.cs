using MediatR;
using Microsoft.AspNetCore.Mvc;
using movie.Application;

namespace movie.Api;
[Route("api/[controller]/[action]")]

[ApiController]
public class MovieController : ControllerBase
{
    private readonly IMediator _mediator;
    public MovieController(IMediator mediator)
    {
        this._mediator = _mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAllMovies()
    {
        var response = await _mediator.Send(new GetAllMoviesQueryRequest());
        return Ok(response);
    }
}
