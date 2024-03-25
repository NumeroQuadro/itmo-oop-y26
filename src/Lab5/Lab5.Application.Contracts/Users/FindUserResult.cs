namespace Lab5.Application.Contracts.Users;

public abstract record FindUserResult
{
    private FindUserResult()
    { }

    public sealed record Success : FindUserResult;
    public sealed record NotFound : FindUserResult;
}