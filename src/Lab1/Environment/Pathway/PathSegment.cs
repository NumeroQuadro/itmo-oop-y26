using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public class PathSegment : IPathSegment
{
    private readonly List<IEnvironment> _environments;

    public PathSegment(IEnumerable<IEnvironment> environments)
    {
        _environments = environments.ToList();
    }

    public SpaceTravelResult? GoThroughAllEnvironmentsAndGetResultOfTrip(ISpaceShuttle shuttle)
    {
        foreach (IEnvironment environment in _environments)
        {
            SpaceTravelResult? result = shuttle.FlyToEnvironmentAndGetResult(environment);
            if (result != null)
            {
                return result;
            }
        }

        return null;
    }
}