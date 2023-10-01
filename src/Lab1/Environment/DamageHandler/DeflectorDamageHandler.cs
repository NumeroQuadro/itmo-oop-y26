using System;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.DamageHandler;

public class DeflectorDamageHandler : ShipHullDamageHandler
{
    private double _deflectorHitPoints;

    public DeflectorDamageHandler(double deflectorHitPoints, double shipHullHitPoints)
        : base(shipHullHitPoints)
    {
        _deflectorHitPoints = deflectorHitPoints;
    }

    public override SpaceTravelResult? DealDamage(double hitPoints)
    {
        Console.WriteLine($"ну я дефлектор получаю дамаг, у меня {_deflectorHitPoints}");
        if (hitPoints >= _deflectorHitPoints || _deflectorHitPoints <= 0)
        {
            return base.DealDamage(hitPoints);
        }

        _deflectorHitPoints -= hitPoints;
        return null;
    }
}