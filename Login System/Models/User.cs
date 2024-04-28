namespace Login_System.Models
{
    public class User
    {
        public Guid Id { get; set; }=Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

    }
}
