namespace Core.Models
{
    public class Accounting
    {
        public const int MAX_LENGTH = 250;
        private Accounting(int storeId, DateOnly date, string description)
        {
            Id = Guid.NewGuid();
            StoreId = storeId;
            Date = date;
            Description = string.IsNullOrEmpty(description) ? description : string.Empty;
            Status = "Ожидает";
        }

        public Guid Id { get; }
        public int StoreId { get; }
        public DateOnly Date { get; }
        public TimeOnly Start { get; }
        public TimeOnly End { get; }
        public string Status { get; } = string.Empty;
        public string Description { get; } = string.Empty;

        static public (Accounting Accounting, string Error) Create(int storeId, DateOnly date, string description)
        {
            var error = string.Empty;

            //if

            var accounting = new Accounting(storeId, date, description);

            return (accounting, error);
        }
    }
}
