namespace ManagementOfWatchedFilms.Infrastructure.Core.Entity.Exceptions
{
    public class UniversalErrorCode
    {
        private const char Constant = 'U';

        public static HandleErrorCode U000 => new HandleErrorCode
        {
            Code = $"{Constant}-001",
            Description = "Undefined error"
        };

        public static HandleErrorCode U001 => new HandleErrorCode
        {
            Code = $"{Constant}-001",
            Description = "Argument object is null"
        };

        public static HandleErrorCode U002 => new HandleErrorCode
        {
            Code = $"{Constant}-002",
            Description = "Argument entity ID is null"
        };

        public static HandleErrorCode U003 => new HandleErrorCode
        {
            Code = $"{Constant}-003",
            Description = "Argument variable is null"
        };

        public static HandleErrorCode U004 => new HandleErrorCode
        {
            Code = $"{Constant}-004",
            Description = "Argument entity property is null"
        };

        public static HandleErrorCode U005 => new HandleErrorCode
        {
            Code = $"{Constant}-005",
            Description = "The request did not return any value "
        };
    }
}