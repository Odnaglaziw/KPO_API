namespace DataAccess.Entities
{
    public class AttendanceEntity
    {
        public Guid Id { get; }
        public Guid AccountingId { get; }
        public Guid EmplayeeId { get; }
        public string ArrivalCode { get; } = string.Empty;
        public TimeOnly ArrivalTime { get; }
        public TimeOnly DepartureTime { get; }
    }
}
