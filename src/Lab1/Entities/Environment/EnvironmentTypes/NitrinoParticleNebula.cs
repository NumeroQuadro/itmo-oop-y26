using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.Engine.ImpulseEngines;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public class NitrinoParticleNebula : IEnvironment
{
    private List<IObstacle> _obstacles;

    public NitrinoParticleNebula(uint numberOfSpaceWhales, uint length)
    {
        _obstacles = new List<IObstacle>();
        AddSpaceWhales(numberOfSpaceWhales);
        Length = length;
    }

    public uint Length { get; init; }

    public bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle)
    {
        if (shuttle.ImpulseEngine is not EClassImpulseEngine || Length > shuttle.ImpulseEngine.MaxLength)
        {
            return false;
        }

        return true;
    }

    public void AddSpaceWhales(uint numberOfSpaceWhales)
    {
        for (uint i = 0; i < numberOfSpaceWhales; ++i)
        {
            _obstacles.Add(new SpaceWhale());
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