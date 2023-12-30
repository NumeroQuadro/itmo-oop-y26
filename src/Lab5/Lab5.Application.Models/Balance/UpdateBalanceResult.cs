namespace Lab5.Application.Models.Balance;

public abstract record UpdateBalanceResult
{
    private UpdateBalanceResult()
    { }

    public sealed record Success : UpdateBalanceResult;
    public sealed record NotEnoughMoney : UpdateBalanceResult;
    public sealed record UserNotFound : UpdateBalanceResult;
}