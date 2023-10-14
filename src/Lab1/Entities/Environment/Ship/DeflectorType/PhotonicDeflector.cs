using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public class PhotonicDeflector : IDeflector, IProtectFromDustingAntiMatter
{
    private readonly IDeflector _deflectorType;
    private int _hitPoints = 3;

    public PhotonicDeflector(IDeflector deflectorType)
    {
        _deflectorType = deflectorType;
    }

    public ProtectionState TakeDamageAndGetResult(double hitPoints)
    {
        return _deflectorType.TakeDamageAndGetResult(hitPoints);
    }

    public SpaceTravelResult TakeDustingOfAntiMatterResult()
    {
        if (_hitPoints >= 1)
        {
            --_hitPoints;
            return new SpaceTravelResult.Success();
        }

        _hitPoints = 0;

        return new SpaceTravelResult.CrewDeath();
    }
}