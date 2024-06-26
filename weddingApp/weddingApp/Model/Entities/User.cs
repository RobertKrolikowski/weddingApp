namespace weddingApp.Model.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime LastLoginDate { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
