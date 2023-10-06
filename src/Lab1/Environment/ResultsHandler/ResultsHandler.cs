using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;

public class ResultsHandler
{
    private readonly IDictionary<SpaceTravelResult, ISpaceShuttle> _comprasionValues = new Dictionary<SpaceTravelResult, ISpaceShuttle>();

    public void AddValue(SpaceTravelResult result, ISpaceShuttle shuttle)
    {
        if (result is Success)
        {
            _comprasionValues.Add(result, shuttle);
        }
    }

    public ISpaceShuttle? GetShuttleWhichIsMoreProfit(IEnvironment environment)
    {
        if (environment is Space)
        {
            return FindBestShuttleInSpace();
        }

        if (environment is NebulaInHighDensitySpace)
        {
            double maxJumpEngineLength = 0;
            ISpaceShuttle? answerShuttle = null;

            foreach (KeyValuePair<SpaceTravelResult, ISpaceShuttle> pair in _comprasionValues)
            {
                if (pair.Value.JumpEngine is not null)
                {
                    if (pair.Value.JumpEngine.MaxLength < maxJumpEngineLength)
                    {
                        maxJumpEngineLength = pair.Value.JumpEngine.MaxLength;
                        answerShuttle = pair.Value;
                    }
                }

                return answerShuttle;
            }
        }

        return null;
    }

    private ISpaceShuttle? FindBestShuttleInSpace()
    {
        double minimalPrice = double.MaxValue;
        ISpaceShuttle? answerShuttle = null;
        foreach (KeyValuePair<SpaceTravelResult, ISpaceShuttle> pair in _comprasionValues)
        {
            if (pair.Key is Success)
            {
                if ((pair.Key.BurnedActivePlasmaFuel * Constants.PriceForActivePlasmaFuel) +
                    (pair.Key.BurnedGravitonFuel * Constants.PriceForGravitonFuel) < minimalPrice)
                {
                    minimalPrice = pair.Key.BurnedGravitonFuel * Constants.PriceForGravitonFuel;
                    answerShuttle = pair.Value;
                }
            }
        }

        return answerShuttle;
    }
}