namespace API.Contracts
{
    public record EmployeeRequest(
        string Login,
        string Password,
        string Name,
        string LastName,
        string Position
        );
}
