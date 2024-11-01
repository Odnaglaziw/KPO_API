namespace DataAccess.Entities
{
    public class AttendanceEntity
    {
        public Guid Id { get; set; }
        public Guid AccountingId { get; set; }
        public Guid EmployeeId { get; set; }
        public string ArrivalCode { get; set; } = string.Empty;
        public TimeOnly ArrivalTime { get; set; }
        public TimeOnly DepartureTime { get; set; }
    }
}
