namespace Lab5.Application.Models.Balance;

public abstract record CheckBalanceResult
{
    private CheckBalanceResult() { }

    public sealed record Success(decimal Balance) : CheckBalanceResult;
    public sealed record BalanceInformationNotFound : CheckBalanceResult;
}