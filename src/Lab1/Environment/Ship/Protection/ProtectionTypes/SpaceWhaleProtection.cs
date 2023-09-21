namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public class SpaceWhaleProtection : Protection
{
    private uint SpaceWhaleCounter { get; set; } = 2;

    public override void TakeDamage()
    {
        --SpaceWhaleCounter;
    }

    public override ProtectionCondition ProtectionCondition()
    {
        if (SpaceWhaleCounter != 0)
        {
            return new IsWorking();
        }

        return new IsDestroyed();
    }
}