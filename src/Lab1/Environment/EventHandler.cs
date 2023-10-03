using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment;

internal static class EventHandler
{
    public static void HandleEvent(SpaceTravelResult? spaceTravelResult)
    {
        if (spaceTravelResult == null)
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