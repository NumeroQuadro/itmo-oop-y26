using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class NebulaInHighDensitySpace : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NebulaInHighDensitySpace(uint numberOfDustingOfAntiMatters, uint length)
    {
        _obstacles = new List<IObstacle>();
        AddDustingOfAntiMatters(numberOfDustingOfAntiMatters);
        Length = length;
    }

    public uint Length { get; }

    public bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle)
    {
        if (shuttle.JumpEngine is null || Length > shuttle.JumpEngine.MaxLength)
        {
            return false;
        }

        return true;
    }

    public void AddDustingOfAntiMatters(uint numberOfDustingOfAntiMatters)
    {
        for (uint i = 0; i < numberOfDustingOfAntiMatters; ++i)
        {
            _obstacles.Add(new DustingOfAntiMatter());
        }
    }

    public IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }

    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle)
    {
        if (IsShuttlePossibleToStayInCurrentEnvironment(shuttle))
        {
            return GetShuttleThroughAllObstacles(shuttle);
        }

        return new ImpossibleToGoToEnvironment();
    }

    private SpaceTravelResult GetShuttleThroughAllObstacles(ISpaceShuttle shuttle)
    {
        IEnumerable<IObstacle> obstacles = GetObstacles();
        foreach (IObstacle obstacle in obstacles)
        {
            SpaceTravelResult result = obstacle.DealDamageAndGetShipCondition(shuttle);
            if (result is not Success)
            {
                return result;
            }
        }

        return new Success();
    }
}