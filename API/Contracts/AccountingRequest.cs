namespace API.Contracts
{
    public record AccountingRequest(int StoreId,
        DateOnly Date,
        TimeOnly Start,
        TimeOnly End,
        string Status,
        string Description
        );
}
