using AccountService.Domain.Null;

namespace AccountService.Domain.Models
{
    public class AwardData
    {
        public Guid Id { get; set; }
        public string AwardName { get; set; } = new NullItem().DefaultData;
        public string AwardImageUrl { get; set; } = new NullItem().DefaultData;
    }
}
