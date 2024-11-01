namespace DataAccess.Entities
{
    public class AccountingEntity
    {
        public Guid Id { get; }
        public int StoreId { get; }
        public DateOnly Date { get; }
        public TimeOnly Start { get; }
        public TimeOnly End { get; }
        public string Status { get; } = string.Empty;
        public string Description { get; } = string.Empty;
    }
}
