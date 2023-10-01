using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class DustingOfAntiMatter : INebulaInHighDensitySpaceObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (shuttle.HasPhotonModificator)
        {
            SpaceTravelResult? shuttleConditionAfterDamaged = shuttle.TakeDamageAndGetResult(4);
            if (shuttleConditionAfterDamaged == null)
            {
                throw new ArgumentException("Ship was damaged, but returned null ProtectionCondition variable!");
            }

            return shuttleConditionAfterDamaged;
        }

        return new ShuttleIsDestroyed();
    }
}