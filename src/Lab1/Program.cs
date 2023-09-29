using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var shuttle = new VaklasShuttle();

        shuttle.TakeDamageAndGetSpaceShuttleCondition(new Meteor());
        var ship = new MeredianShuttle();
    }
}