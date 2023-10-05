namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface ISpaceShuttle : IMovement
{
    public bool HasPhotonModificator { get; }
    public bool HasAntiNitrinoEmitter { get; }
    public SpaceTravelResult? TakeDamageAndGetResult(double hitPoints);
    public SpaceTravelResult? TakeSpecialDamageAndGetResult(double hitPoints);
}