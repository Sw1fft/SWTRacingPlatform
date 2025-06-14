using AccountService.Domain.Null;

namespace AccountService.Domain.Models
{
    public class GameInfo
    {
        public Guid Id { get; set; }
        public string GameName { get; set; } = new NullItem().DefaultData;
        public int RatingPoints { get; set; }
        public int WinRate { get; set; }
        public string GameImageUrl { get; set; } = new NullItem().DefaultData;

        public override string ToString()
        {
            return $"Id: {Id}," +
                $"GameName: {GameName}," +
                $"RatingPoints: {RatingPoints}," +
                $"WinRate: {WinRate}," +
                $"GameImageUrl: {GameImageUrl}";
        }
    }
}
