using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection.ProtectionConditions;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class Asteroid : ISpaceObstacle
{
    public Asteroid(IEnvironment environment)
    {
        CurrentEnvironment = environment;
    }

    public IEnvironment CurrentEnvironment { get; init; }

    public void DealDamage(ISpaceShuttle shuttle)
    {
        if (CurrentEnvironment == shuttle.CurrentEnvironment)
        {
            ProtectionCondition? shuttleConditionAfterDamaged = shuttle.TakeDamageAndGetResult(4);
            if (shuttleConditionAfterDamaged == null)
            {
                throw new ArgumentException("Ship was damaged, but returned null ProtectionCondition variable!");
            }
        }

        throw new ArgumentException("Cannot deal damage! Asteroid is in another Environment rather than shuttle!");
    }
}