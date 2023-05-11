namespace PaletteStudioApi.Exceptions
{
    public class UnauthorizedException : ApplicationException
    {
        public UnauthorizedException(string name, string username) : base($"User {username} is not authorized for {name}.")
        {

        }
    }
}
