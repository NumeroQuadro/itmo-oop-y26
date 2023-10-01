using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;

public class ShipHullDamageHandler : DamageHandler
{
    private double _shipHullHitPoints;

    public ShipHullDamageHandler(double hitPoints)
    {
        _shipHullHitPoints = hitPoints;
    }

    public override SpaceTravelResult? DealDamage(double hitPoints)
    {
        Console.WriteLine($"ну я блин корпус, получаю дамаг щас, вопросы? у меня хп {_shipHullHitPoints}");
        if (hitPoints > _shipHullHitPoints || _shipHullHitPoints <= 0)
        {
            return new ShuttleIsDestroyed();
        }

        _shipHullHitPoints -= hitPoints;
        return null;
    }
}