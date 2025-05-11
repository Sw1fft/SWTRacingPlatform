namespace IdentityService.Domain.Models
{
    public class User
    {
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public User()
        {
            Username = "default_user";
            FirstName = "default_firstname";
            LastName = "default_lastname";
            Email = "default@gmail.com";
            Phone = "+79999999999";
            Password = "default_password";
        }

        public override string ToString()
        {
            return $"Username: {Username}, FirstName: {FirstName}, LastName: {LastName}, Email: {Email}, Phone: {Phone}, Password: {Password}";
        }
    }
}
