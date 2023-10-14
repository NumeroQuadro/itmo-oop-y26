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

    public double GetTime(ISpaceShuttle shuttle)
    {
        double zeroTime = 0;

        if (_environment is Space or NitrinoParticleNebula)
        {
            if (shuttle.ImpulseEngine != null) return shuttle.ImpulseEngine.GetWastedTimeBySpecialFormula(Length);
        }
        else if (_environment is NebulaInHighDensitySpace)
        {
            if (shuttle.JumpEngine != null) return shuttle.JumpEngine.GetWastedTimeBySpecialFormula(Length);
        }

        return zeroTime;
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