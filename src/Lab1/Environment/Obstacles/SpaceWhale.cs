using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class SpaceWhale : INitrinoParticleNebulaObstacle
{
    public SpaceWhale(IEnvironment environment)
    {
        CurrentEnvironment = environment;
    }

    public IEnvironment CurrentEnvironment { get; init; }

    public SpaceTravelResult DealDamageAndGetShipCondition(ISpaceShuttle shuttle)
    {
        if (CurrentEnvironment == shuttle.CurrentEnvironment)
        {
            if (shuttle.HasAntiNitrinoEmitter)
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

        throw new ArgumentException("Cannot deal damage! Space Whale is in another Environment rather than shuttle!");
    }
}