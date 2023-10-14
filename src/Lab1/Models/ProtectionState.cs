namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public abstract record ProtectionState
{
    private ProtectionState() { }
    public sealed record ProtectionIsEnabled : ProtectionState;
    public sealed record ImpossibleToBeDamaged : ProtectionState;
}