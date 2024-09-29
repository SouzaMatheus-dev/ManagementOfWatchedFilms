using Newtonsoft.Json;

namespace ManagementOfWatchedFilms.API.Infrastructure.Models
{
    public class ApiErrorCodeResponse
    {
        [JsonProperty("errorCode")]
        public string ErrorCode { get; set; }
    }
}