using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        var environments = new List<IEnvironment>() { new Space(1, 0), new Space(0, 33) };
        var environments2 = new List<IEnvironment>() { new Space(1, 1) };

        var segment = new PathSegment(environments);
        var segment2 = new PathSegment(environments2);

        var segments = new List<PathSegment>() { segment, segment2 };

        var route = new Route(segments.AsReadOnly());

        var shuttle = new MeredianShuttle();
        SpaceTravelResult? result = route.GoThroughAllSegmentsAndGetResultOfTrip(shuttle);
        EventHandler.HandleEvent(result);
    }
}