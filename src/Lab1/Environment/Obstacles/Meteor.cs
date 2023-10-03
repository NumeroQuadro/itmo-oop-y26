using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Meteor : ISpaceObstacle
{
    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        SpaceTravelResult? shuttleConditionAfterDamaged = shuttle.TakeDamageAndGetResult(Constants.MeteorDamage);
        if (shuttleConditionAfterDamaged == null)
        {
            throw new ArgumentException("Ship was damaged, but returned null ProtectionCondition variable!");
        }

        return shuttleConditionAfterDamaged;
    }
}