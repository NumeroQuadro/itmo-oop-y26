using Lab5.Presentation.Console.Scenarios.CheckBalanceScenarios;
using Lab5.Presentation.Console.Scenarios.CreateAccountScenarios;
using Lab5.Presentation.Console.Scenarios.DepositScenarios;
using Lab5.Presentation.Console.Scenarios.LoginScenarios;
using Lab5.Presentation.Console.Scenarios.ViewTransactionHistoryScenarios;
using Lab5.Presentation.Console.Scenarios.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawScenarioProvider>();
        collection.AddScoped<IScenarioProvider, DepositScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CheckBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, CreateAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewTransactionHistoryScenarioProvider>();
        return collection;
    }
}