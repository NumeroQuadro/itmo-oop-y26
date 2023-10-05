using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public interface IPathSegment
{
    public SpaceTravelResult GoThroughAllEnvironmentsAndGetResultOfTrip(ISpaceShuttle shuttle);
}