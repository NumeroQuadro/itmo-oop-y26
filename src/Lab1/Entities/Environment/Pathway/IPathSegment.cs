using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Pathway;

public interface IPathSegment
{
    public SpaceTravelResult GoThroughAllEnvironmentsAndGetResultOfTrip(ISpaceShuttle shuttle);
    public double CalculateEnvironmentsDistances();
}