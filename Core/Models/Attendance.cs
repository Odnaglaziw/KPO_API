namespace Core.Models
{
    public class Attendance
    {
        private Attendance(Guid accountingId, Guid employeeId, string arrivalCode)
        {
            Id = Guid.NewGuid();
            AccountingId = accountingId;
            EmployeeId = employeeId;
            ArrivalCode = arrivalCode;
        }

        public Guid Id { get; }
        public Guid AccountingId { get; }
        public Guid EmployeeId { get; }
        public string ArrivalCode { get; } = string.Empty;
        public TimeOnly ArrivalTime { get; }
        public TimeOnly DepartureTime { get; }

        static public (Attendance Attendance, string Error) Create(Guid accountingId,Guid employeeId, string arrivalCode)
        {
            var error = string.Empty;

            //if

            var attendance = new Attendance(accountingId, employeeId, arrivalCode);

            return (attendance, error);
        }
    }
}
