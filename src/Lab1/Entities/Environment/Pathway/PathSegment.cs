using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.JumpEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Pathway;

public class PathSegment : IPathSegment
{
    private readonly List<IEnvironment> _environments;

    public PathSegment(IEnumerable<IEnvironment> environments)
    {
        _environments = environments.ToList();
        ActivePlasmaFuel = new ActivePlasmaFuel();
        GravitonFuel = new GravitonFuel();
        ImpulseEngineWorkingTime = new ImpulseEngineWorkingTime();
        JumpEngineWorkingTime = new JumpEngineWorkingTime();
    }

    public ActivePlasmaFuel ActivePlasmaFuel { get; }
    public GravitonFuel GravitonFuel { get; }
    public ImpulseEngineWorkingTime ImpulseEngineWorkingTime { get; }
    public JumpEngineWorkingTime JumpEngineWorkingTime { get; }

    public SpaceTravelResult GoThroughAllEnvironmentsAndGetResultOfTrip(ISpaceShuttle shuttle)
    {
        foreach (IEnvironment environment in _environments)
        {
            SpaceTravelResult result = environment.TakeOverTheShip(shuttle);
            if (result is not Success)
            {
                return result;
            }

            CalculateFuelPerEngineStart(shuttle.ImpulseEngine, shuttle.JumpEngine, environment);
        }

        double totalDistance = CalculateEnvironmentsDistances();
        CountMeasurablesValuesAfterSpaceTravel(shuttle, totalDistance);

        return new Success();
    }

    public double CalculateEnvironmentsDistances()
    {
        double totalDistance = 0;
        foreach (IEnvironment environment in _environments)
        {
            totalDistance += environment.Length;
        }

        return totalDistance;
    }

    private void CountMeasurablesValuesAfterSpaceTravel(ISpaceShuttle shuttle, double totalDistance)
    {
        if (shuttle.ImpulseEngine is not null)
        {
            ActivePlasmaFuel.CalculateAndIncreaseMesurableValue(shuttle.ImpulseEngine, totalDistance);
            ImpulseEngineWorkingTime.CalculateAndIncreaseMesurableValue(shuttle.ImpulseEngine, totalDistance);
        }

        if (shuttle.JumpEngine is not null)
        {
            GravitonFuel.CalculateAndIncreaseMesurableValue(shuttle.JumpEngine, totalDistance);
            JumpEngineWorkingTime.CalculateAndIncreaseMesurableValue(shuttle.JumpEngine, totalDistance);
        }
    }

    private void CalculateFuelPerEngineStart(IImpulseEngine? impulseEngine, IJumpEngine? jumpEngine, IEnvironment environment)
    {
        if (environment is ISpace)
        {
            if (impulseEngine != null)
            {
                ActivePlasmaFuel.AddAmountOfMeasurableValue(impulseEngine.GetWastedFuelForStartBySpecialFormula());
            }
        }
        else
        {
            if (jumpEngine != null)
            {
                GravitonFuel.AddAmountOfMeasurableValue(jumpEngine.GetWastedFuelForStartBySpecialFormula());
            }
        }
    }
}