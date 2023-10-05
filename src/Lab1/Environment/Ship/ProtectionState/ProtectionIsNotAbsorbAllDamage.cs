namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.ProtectionState;

public sealed record ProtectionIsNotAbsorbAllDamage(double RemainingUnAbsorbedDamage) : ProtectionState;