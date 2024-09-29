namespace ManagementOfWatchedFilms.Infrastructure.Core.Entity.Exceptions
{
    public static class MovieErrorCode
    {
        private const string Constant = "M";

        public static HandleErrorCode M001 => new()
        {
            Code = $"{Constant}-001",
            Description = "Movie not found"
        };
    }
}