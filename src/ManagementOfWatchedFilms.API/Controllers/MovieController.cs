using AutoMapper;
using ManagementOfWatchedFilms.API.Infrastructure.Models;
using ManagementOfWatchedFilms.API.Models.Movie;
using ManagementOfWatchedFilms.Domain.Entity;
using ManagementOfWatchedFilms.Domain.Interface.Repository;
using ManagementOfWatchedFilms.Domain.Interface.Service;
using ManagementOfWatchedFilms.Infrastructure.Core.Extensions;
using ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb;
using Microsoft.AspNetCore.Mvc;

namespace ManagementOfWatchedFilms.Controllers
{
    [ApiController]
    [Route("movies")]
    public class MovieController : ControllerBase
    {
        private readonly ILogger<MovieController> _logger;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMovieService _movieService;
        private readonly IMDb _iMDb;

        public MovieController(
            ILogger<MovieController> logger,
            IMapper mapper,
            IUnitOfWork unitOfWork, IMovieService movieService,
            IMDb iMDb)
        {
            _logger = logger;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _movieService = movieService;
            _iMDb = iMDb;
        }

        [HttpPost("register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Register(MovieRequest request)
        {
            if (request == null || !ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieRequest, Movie>(request);

            await _movieService.AddAsync(movie);
            await _unitOfWork.CommitAsync();

            return Ok("Filme gravado com sucesso");
        }

        [HttpDelete("delete/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> DeleteCreditCard(Guid id)
        {
            if (id.IsEmpty())
                return BadRequest();

            await _movieService.DeleteByIdAsync(id);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpPatch("update/{id:guid}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateRideId([FromRoute] Guid id, [FromBody] MovieRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var movie = _mapper.Map<MovieRequest, Movie>(request);

            await _movieService.UpdateByIdAsync(id, movie);
            await _unitOfWork.CommitAsync();

            return Ok();
        }

        [HttpGet("list")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> List()
        {
            var results = await _movieService.GetAllAsync();

            var movies = _mapper.Map<List<Movie>, List<MovieResponse>>(results);

            foreach (var movie in movies)
            {
                var resultImdb = await _iMDb.GetMovieByCode(movie.IMDbId);
                movie.UserScoreIMDb = resultImdb.ImdbRating;
            }

            return Ok(movies);
        }

        [HttpGet("list-by-watched")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(typeof(ApiErrorCodeResponse), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ListByWatched()
        {
            var results = await _movieService.GetAllMoviesWatchedAsync();

            var movies = _mapper.Map<List<Movie>, List<MovieResponse>>(results);

            foreach (var movie in movies)
            {
                var resultImdb = await _iMDb.GetMovieByCode(movie.IMDbId);
                movie.UserScoreIMDb = resultImdb.ImdbRating;
            }

            return Ok(movies);
        }
    }
}