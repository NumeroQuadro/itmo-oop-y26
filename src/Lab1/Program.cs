using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.TypeOfShips;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Program
{
    public static void Main()
    {
        // var environments = new List<IEnvironment>() { new Space(1, 0), new Space(0, 33) };
        // var environments2 = new List<IEnvironment>() { new Space(1, 1) };
        //
        // var segment = new PathSegment(environments);
        // var segment2 = new PathSegment(environments2);
        //
        // var segments = new List<PathSegment>() { segment, segment2 };
        //
        // var route = new Route(segments.AsReadOnly());
        //
        // var shuttle = new MeredianShuttle(false);
        // SpaceTravelResult? result = route.GoThroughAllSegmentsAndGetResultOfTrip(shuttle);
        // EventHandler.HandleEvent(result);
        var environment = new NitrinoParticleNebula(1, 45);
        var shuttle = new VaklasShuttle(false);

        SpaceTravelResult? result = shuttle.FlyToEnvironmentAndGetResult(environment);
        if (result is Success)
        {
            return;
        }
    }
}