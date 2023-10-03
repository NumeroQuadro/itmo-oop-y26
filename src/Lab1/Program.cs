using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        ISpace space = new Space();
        space.AddAsteroids(17);

        var shuttle = new MeredianShuttle();
        SpaceTravelResult? result = shuttle.FlyToEnvironmentAndGetResult(space);
        if (result is ShuttleIsDestroyed)
        {
            Console.WriteLine("Shuttle was destroyed :(((");
        }
    }
}