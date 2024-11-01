namespace API.Contracts
{
    public record AttendanceResponse(Guid id,
        Guid AccountingId,
        Guid EmployeeId,
        string ArrivalCode,
        TimeOnly ArrivalTime,
        TimeOnly DepartureTime
        );
}
