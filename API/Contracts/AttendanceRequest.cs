namespace API.Contracts
{
    public record AttendanceRequest(Guid AccountingId,
        Guid EmployeeId,
        string ArrivalCode,
        TimeOnly ArrivalTime,
        TimeOnly DepartureTime
        );
}
