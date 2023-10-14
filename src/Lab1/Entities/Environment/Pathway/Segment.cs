using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;

public class Segment
{
    private readonly IEnvironment _environment;
    private readonly double _length;

    public Segment(IEnvironment environment, double length)
    {
        _environment = environment;
        _length = length;
    }

    public double Length => _length;
    public IEnvironment Environment => _environment;

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        if (IsShuttlePossibleToStayInCurrentSegment(shuttle))
        {
            return _environment.TakeOverTheShip(shuttle);
        }

        return new SpaceTravelResult.ImpossibleToGoToEnvironment();
    }

    private bool IsShuttlePossibleToStayInCurrentSegment(ISpaceShuttle shuttle)
    {
        if (shuttle.JumpEngine is null || !shuttle.JumpEngine.IsEnoughLengthToFly(_length))
        {
            return false;
        }

        return true;
    }
}