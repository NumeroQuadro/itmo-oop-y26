using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.ServiceCollectionExtensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();

        return collection;
    }
}