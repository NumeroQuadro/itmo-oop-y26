using Itmo.ObjectOrientedProgramming.Lab1.Asteroid;
using Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship.Protection;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Ship;

public class Deflector
{
    private readonly ProtectionType _protectionType;
    private readonly AntiMatterProtection _antiMatterProtection;
    private readonly LightProtection _lightProtection;
    private readonly HeavyProtection _heavyProtection;
    private readonly SpaceWhaleProtection _spaceWhaleProtection;

    public Deflector(ProtectionType protectionType, bool hasPhotonModification)
    {
        const bool heavyProtectionIsNotDisabled = true;

        _protectionType = protectionType;
        HasPhotonModification = hasPhotonModification;
        _antiMatterProtection = new AntiMatterProtection();
        _lightProtection = new LightProtection();
        _heavyProtection = new HeavyProtection(heavyProtectionIsNotDisabled);
        _spaceWhaleProtection = new SpaceWhaleProtection();

        IsDestroyed = false;
    }

    public bool HasPhotonModification { get; private set; }
    public bool IsDestroyed { get; private set; }

    public ProtectionCondition TakeDamageAndGetDeflectorCondition(ObstacleType obstacleType)
    {
        if (IsDestroyed)
        {
            return new IsDestroyed();
        }

        if (obstacleType == ObstacleType.DustingOfAntiMatter & _antiMatterProtection.ProtectionCondition() is IsWorking)
        {
            _antiMatterProtection.TakeDamage();
            return _antiMatterProtection.ProtectionCondition();
        }

        if (obstacleType == ObstacleType.Meteor & _heavyProtection.ProtectionCondition() is IsWorking)
        {
            _heavyProtection.TakeDamage();
            return _heavyProtection.ProtectionCondition();
        }

        if (obstacleType == ObstacleType.SmallAsteroid & _lightProtection.ProtectionCondition() is IsWorking)
        {
            _lightProtection.TakeDamage();
            return _lightProtection.ProtectionCondition();
        }

        if (obstacleType == ObstacleType.SpaceWhale & _spaceWhaleProtection.ProtectionCondition() is IsWorking)
        {
            _spaceWhaleProtection.TakeDamage();
            return _spaceWhaleProtection.ProtectionCondition();
        }

        IsDestroyed = true;

        return new IsDestroyed();
    }
}