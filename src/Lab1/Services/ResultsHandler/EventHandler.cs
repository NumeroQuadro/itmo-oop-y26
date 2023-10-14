using System;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

internal static class EventHandler
{
    public static void HandleEvent(SpaceTravelResult? spaceTravelResult)
    {
        if (spaceTravelResult is SpaceTravelResult.Success)
        {
            Console.WriteLine("Все прошло успешно");
        }
        else if (spaceTravelResult is SpaceTravelResult.ShuttleIsDestroyed)
        {
            Console.WriteLine("Shuttle was destroyed");
        }
        else if (spaceTravelResult is SpaceTravelResult.CrewDeath)
        {
            Console.WriteLine("Crew of shuttle is death :skeleton:");
        }
        else
        {
            Console.WriteLine("Shuttle was lost");
        }
    }
}