namespace API.Contracts
{
    public record EmployeeResponse(
        Guid id,
        string Login,
        string Password,
        string Name,
        string LastName,
        string Position
        );
}
