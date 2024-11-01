namespace API.Contracts
{
    public record AccountingResponse(Guid id,
        int StoreId,
        DateOnly Date,
        TimeOnly Start,
        TimeOnly End,
        string Status,
        string Description
        );
}
