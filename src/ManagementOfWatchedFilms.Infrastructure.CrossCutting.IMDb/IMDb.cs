using ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb.Models.Response;
using ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb.Options;
using Microsoft.Extensions.Options;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ManagementOfWatchedFilms.Infrastructure.CrossCutting.IMDb
{
    public class IMDb
    {
        private readonly IHttpClientFactory _clientFactory;
        private IMDbOptions Options { get; }
        private string HttpClientName { get; }
        private JsonSerializerOptions JsonSerializerOptions { get; }

        public IMDb(IOptions<IMDbOptions> optionsAccessor,
            IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            Options = optionsAccessor.Value;
            HttpClientName = nameof(IMDb);
            JsonSerializerOptions = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter()
                }
            };
        }

        public async Task<MovieResponse> GetMovieByCode(string imdbId)
        {
            var client = _clientFactory.CreateClient(HttpClientName);
            var response = await client.GetAsync($"?i={imdbId}&plot=full&apikey={Options.ApiKey}");
            response.EnsureSuccessStatusCode();
            return Deserialize<MovieResponse>(await response.Content.ReadAsStringAsync());
        }

        private T Deserialize<T>(string content) => JsonSerializer.Deserialize<T>(content, JsonSerializerOptions);
    }
}