using AccountService.Domain.Null;

namespace AccountService.Domain.Models
{
    public class OverviewData
    {
        public Guid Id { get; set; }
        public List<GameInfo> Games { get; set; } = [];
        public string AboutInfo { get; set; } = new NullItem().DefaultData;
        public List<AwardData> Awards { get; set; } = [];
        public int ReputationPoints { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}," +
                $"Games: {Games.Count}," +
                $"AboutInfo: {AboutInfo}," +
                $"Awards: {Awards}," +
                $"ReputationsPoints: {ReputationPoints}";
        }
    }
}
