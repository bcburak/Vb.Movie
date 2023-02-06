using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VB.Movie.Application.Features.Commands;
using VB.Movie.Application.Features.Queries;
using VB.Movie.Attributes;

namespace VB.Movie.Controllers
{
    [ApiKey]
    public class HomeController : Controller
    {
        private readonly IMediator _mediator;
        public HomeController(IMediator mediator)
        {
            _mediator = mediator;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("getAllMovieByImdbId")]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllMovieByImdbId(string? imdbId)
        {
            return Ok(await _mediator.Send(new GetAllMoviesByImdbIdQuery { ImdbId = imdbId }));
        }

        [HttpGet]
        [Route("getAllStoredMovies")]
        public async Task<IActionResult> GetAllStoredMovies()
        {
            return Ok(await _mediator.Send(new GetAllStoredMoviesQuery()));
        }

        [HttpGet]
        [Route("getStoredMovieBySearchToken")]
        public async Task<IActionResult> GetStoredMovieBySearchToken(string? searchToken)
        {
            return Ok(await _mediator.Send(new GetStoredMovieBySearchTokenQuery { SearchToken = searchToken }));
        }

        [HttpDelete("{movieId:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid movieId)
        {
            return Ok(await _mediator.Send(new DeleteMovieByIdCommand { MovieId = movieId }));
        }


    }
}
