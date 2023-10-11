using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

public class Space : ISpace
{
    private List<IObstacle> _obstacles;

    public Space(uint numberOfAsteroids, uint numberOfMeteors, uint length)
    {
        _obstacles = new List<IObstacle>();
        AddAsteroids(numberOfAsteroids);
        AddMeteors(numberOfMeteors);
        Length = length;
    }

    public uint Length { get; init; }

    public bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle)
    {
        if (shuttle.ImpulseEngine is null || Length > shuttle.ImpulseEngine.MaxLength)
        {
            return false;
        }

        return true;
    }

    public void AddMeteors(uint numberOfMeteors)
    {
        for (uint i = 0; i < numberOfMeteors; ++i)
        {
            _obstacles.Add(new Meteor());
        }
    }

    public void AddAsteroids(uint numberOfAsteroids)
    {
        for (uint i = 0; i < numberOfAsteroids; ++i)
        {
            _obstacles.Add(new Asteroid());
        }
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

    private IEnumerable<IObstacle> GetObstacles()
    {
        return _obstacles.AsEnumerable();
    }
}