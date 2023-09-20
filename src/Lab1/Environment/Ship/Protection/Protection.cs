namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

public abstract class Protection
{
    private readonly ProtectionType _protectionType;
    private uint _asteroidCounter;
    private uint _meteorCounter;
    private uint _spaceWhaleCounter;
    private bool _hasModification;

    protected Protection(ProtectionType protectionType, bool hasModification)
    {
        _protectionType = protectionType;

        _meteorCounter = 0;
        _asteroidCounter = 0;
        _spaceWhaleCounter = 0;

        _hasModification = hasModification;
    }

    public abstract void CheckProtectionCondition();
}