using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.ProtectionState;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class DustingOfAntiMatter : INebulaInHighDensitySpaceObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.Deflector is not null && shuttle.Deflector.HasPhotonModification)
        {
            if (shuttle.Deflector.TakeSpecialDamage(Constants.DustingOfAntimatterDamage) is ImpossibleToBeDamaged)
            {
                return new CrewDeath();
            }

            return new Success();
        }

        return new CrewDeath();
    }
}