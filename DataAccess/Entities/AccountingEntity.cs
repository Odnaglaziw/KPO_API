namespace DataAccess.Entities
{
    public class AccountingEntity
    {
        public Guid Id { get; set; }
        public int StoreId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
        public string Status { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
