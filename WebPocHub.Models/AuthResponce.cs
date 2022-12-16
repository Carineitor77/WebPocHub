namespace WebPocHub.Models
{
    public class AuthResponce
    {
        public string Token { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsAuthenticated { get; set; } = false;
    }
}
