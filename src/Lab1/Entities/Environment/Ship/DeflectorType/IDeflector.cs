using Itmo.ObjectOrientedProgramming.Lab1.Models;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.Ship.DeflectorType;

public interface IDeflector
{
    public ProtectionState TakeDamageAndGetResult(double hitPoints);
}