namespace Lab5.Application.Models.Transactions;

public abstract record ViewTransactionResult
{
    private ViewTransactionResult() { }

    public sealed record Success(IEnumerable<Transaction> Transactions) : ViewTransactionResult;
    public sealed record Failure(string Reason) : ViewTransactionResult;
}