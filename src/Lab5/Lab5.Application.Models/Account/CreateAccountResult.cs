namespace Lab5.Application.Models.Account;

public abstract record CreateAccountResult
{
    private CreateAccountResult() { }

    public sealed record Success(string Username, decimal InitialBalance) : CreateAccountResult;
    public sealed record Failure(string Reason) : CreateAccountResult;
}