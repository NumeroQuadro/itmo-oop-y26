using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class DustingOfAntiMatter : INebulaInHighDensitySpaceObstacle
{
    public SpaceTravelResult? DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.HasPhotonModificator)
        {
            return shuttle.TakeDamageAndGetResult(Constants.DustingOfAntimatterDamage);
        }

        return new CrewDeath();
    }
}