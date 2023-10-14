using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Obstacles;

public class DustingOfAntiMatter : INebulaInHighDensitySpaceObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.Deflector is PhotonicDeflector)
        {
            var deflector = (IProtectFromDustingAntiMatter)shuttle.Deflector;

            return deflector.TakeDustingOfAntiMatterResult();
        }

        return new SpaceTravelResult.CrewDeath();
    }
}