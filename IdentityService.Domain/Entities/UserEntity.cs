namespace IdentityService.Domain.Entities
{
    public class UserEntity
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PasswordHash { get; set; }

        public UserEntity()
        {
            Id = Guid.NewGuid();
            Username = "default_user";
            FirstName = "default_firstname";
            LastName = "default_lastname";
            Email = "default@gmail.com";
            Phone = "+79999999999";
            PasswordHash = "default_password";
        }

        public override string ToString()
        {
            return $"Id: {Id}, " +
                $"Username: {Username}, " +
                $"FirstName: {FirstName}, " +
                $"LastName: {LastName}, " +
                $"Email: {Email}, " +
                $"Phone: {Phone}, " +
                $"Password: {PasswordHash}";
        }
    }
}
