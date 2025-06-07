using AccountService.Domain.Null;

namespace AccountService.Domain.Models
{
    public class HeaderContentData
    {
        public Guid Id { get; set; }
        public string UserNickname { get; set; } = new NullItem().DefaultData;
        public string Country { get; set; } = new NullItem().DefaultData;
        public DateOnly RegistrationDate { get; set; } = new NullItem().DefaultDate;
        public string AvatarUrl { get; set; } = new NullItem().DefaultData;
        public string ProfileImageUrl { get; set; } = new NullItem().DefaultData;

        public override string ToString()
        {
            return $"Id: {Id}," +
                $"UserNickname: {UserNickname}," +
                $"Country: {Country}," +
                $"RegistrationDate: {RegistrationDate}," +
                $"AvatarUrl: {AvatarUrl}," +
                $"ProfileImageUrl: {ProfileImageUrl}";
        }
    }
}
