using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

internal static class EventHandler
{
    public static void HandleEvent(SpaceTravelResult? spaceTravelResult)
    {
        if (spaceTravelResult is Success)
        {
            Console.WriteLine("Все прошло успешно");
        }
        else if (spaceTravelResult is ShuttleIsDestroyed)
        {
            Console.WriteLine("Shuttle was destroyed");
        }
        else if (spaceTravelResult is CrewDeath)
        {
            Console.WriteLine("Crew of shuttle is death :skeleton:");
        }
        else
        {
            Console.WriteLine("Shuttle was lost");
        }
    }
}