using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public class PathSegment : IPathSegment
{
    private readonly List<IEnvironment> _environments;

    public PathSegment(IEnumerable<IEnvironment> environments)
    {
        _environments = environments.ToList();
    }

    public SpaceTravelResult GoThroughAllEnvironmentsAndGetResultOfTrip(ISpaceShuttle shuttle)
    {
        double traveledTime = 0;
        double wastedActivePlasmaFuel = 0;
        double wastedGravitonFuel = 0;

        foreach (IEnvironment environment in _environments)
        {
            SpaceTravelResult result = shuttle.FlyToEnvironmentAndGetResult(environment);
            if (result is Success successResult)
            {
                traveledTime += successResult.TraveledTime;
                wastedActivePlasmaFuel += successResult.BurnedActivePlasmaFuel;
                wastedGravitonFuel += successResult.BurnedGravitonFuel;
            }

            if (result is not Success)
            {
                return result;
            }
        }

        return new Success(wastedActivePlasmaFuel, wastedGravitonFuel, traveledTime);
    }
}