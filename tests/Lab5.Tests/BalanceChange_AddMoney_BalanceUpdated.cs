using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models.Users;
using Lab5.Application.Transactions;
using Lab5.Application.Users;
using Lab5.Presentation.Console;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class BalanceChange_AddMoney_BalanceUpdated
{
    [Fact]
    public void FilterMessage_ReturnNull()
    {
        string username = "dimon";
        decimal balance = 239;

        IUserRepository userRepository = Substitute.For<MockableUserRepository>(balance);
        ITransactionRepository transactionRepository = Substitute.For<MockableTransactionRepository>();
        IScenario depositScenario = Substitute.For<MockableDepositScenario>(new UserService(userRepository, new CurrentUserManager()), new RecordTransactionService(transactionRepository), new User(username, "239239", balance), balance);

        depositScenario.Run();

        // Assert.True(userRepository.GetBalance(username).Result == 239);
        userRepository.Received().UpdateBalance(Arg.Is(username), Arg.Is<decimal>(x => x == 239));
    }
}