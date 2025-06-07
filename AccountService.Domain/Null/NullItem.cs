namespace AccountService.Domain.Null
{
    public class NullItem
    {
        public string DefaultData { get; set; } = "NoContent";
        public DateOnly DefaultDate { get; set; } = new DateOnly();
    }
}
