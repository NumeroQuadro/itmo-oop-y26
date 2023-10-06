using Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public interface IPathSegment
{
    public TripResultInformation GoThroughAllEnvironmentsAndGetResultOfTrip(ISpaceShuttle shuttle);
}