namespace Core.Models
{
    public class Attendance
    {
        private Attendance(Guid accountingId, Guid emplayeeId, string arrivalCode)
        {
            Id = Guid.NewGuid();
            AccountingId = accountingId;
            EmplayeeId = emplayeeId;
            ArrivalCode = arrivalCode;
        }

        public Guid Id { get; }
        public Guid AccountingId { get; }
        public Guid EmplayeeId { get; }
        public string ArrivalCode { get; }
        public TimeOnly ArrivalTime { get; }
        public TimeOnly DepartureTime { get; }

        static public (Attendance Attendance, string Error) Create(Guid accountingId,Guid emplayeeId, string arrivalCode)
        {
            var error = string.Empty;

            //if

            var attendance = new Attendance(accountingId, emplayeeId, arrivalCode);

            return (attendance, error);
        }
    }
}
