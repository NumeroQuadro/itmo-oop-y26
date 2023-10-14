using Itmo.ObjectOrientedProgramming.Lab1.Models;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public interface IPhotonicDeflector
{
    public SpaceTravelResult TakeDustingOfAntiMatterResult();
    public ProtectionState TakeDamageAndGetResult(double hitPoints);
}