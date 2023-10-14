using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;

public class Segment
{
    private IEnvironment _environment;
    private double _length;

    public Segment(IEnvironment environment, double length)
    {
        _environment = environment;
        _length = length;
    }

    public double Length => _length;

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        return _environment.TakeOverTheShip(shuttle);
    }
}