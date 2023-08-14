namespace OnlineLibrary.Domain.Entites.Identity
{
    public class UserRefreshToken
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public string UserName { get; set; }
        public DateTime ExpiresTime { get; set; }
    }
}
