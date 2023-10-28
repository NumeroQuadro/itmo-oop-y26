using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;

public class Segment
{
    private readonly IEnvironment _environment;
    private readonly double _length;
    private readonly FuelMarket _market;

    public Segment(IEnvironment environment, double length)
    {
        _environment = environment;
        _length = length;
        _market = new FuelMarket();
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

    public void IncreaseWastedAmountOfActivePlasma(ISpaceShuttle shuttle, double length)
    {
        if (shuttle.ImpulseEngine is not null)
        {
            _market.IncreaseAmountOfActivePlasma(shuttle.ImpulseEngine.GetWastedFuelBySpecialFormula(length));
        }
    }

    public void IncreaseWastedAmountOfGravitonFuel(ISpaceShuttle shuttle, double length)
    {
        if (shuttle.JumpEngine is not null)
        {
            _market.IncreaseAmountOfGravitonFuel(shuttle.JumpEngine.GetWastedFuelBySpecialFormula(length));
        }
    }

    public void SetWastedAmountOfActivePlasma(FuelMarket market)
    {
        market.IncreaseAmountOfActivePlasma(_market.GetAmountOfActivePlasma);
    }

    public void SetWastedAmountOfGravitonFuel(FuelMarket market)
    {
        market.IncreaseAmountOfGravitonFuel(_market.GetAmountOfGravitonFuel);
    }

    public double GetTime(ISpaceShuttle shuttle)
    {
        const double zeroTime = 0;

        if (_environment is Space or NitrinoParticleNebula && shuttle.ImpulseEngine is not null)
        {
            return shuttle.ImpulseEngine.GetWastedTimeBySpecialFormula(Length);
        }

        if (_environment is NebulaInHighDensitySpace && shuttle.JumpEngine is not null)
        {
            return shuttle.JumpEngine.GetWastedTimeBySpecialFormula(Length);
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