using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services;

public class FlightSimulation
{
    private Route _route;
    private ISpaceShuttle _shuttle;

    public FlightSimulation(Route route, ISpaceShuttle shuttle)
    {
        _route = route;
        _shuttle = shuttle;
    }

    public SpaceTravelResult StartSimulation()
    {
        return _route.Travel(_shuttle);
    }
}