namespace PaletteStudioClient.Models.Authentication
{
    public class AuthResponse
    {
        public string UserId { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
