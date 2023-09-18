namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Deflector
{
    private readonly DeflectorClass _deflectorClass;
    private uint _smallAsteroidCounter;
    private uint _bigAsteroidCounter;
    private bool _isEnable;
    private bool _isModified;

    // field for spaceWhale
    public Deflector(DeflectorClass deflectorClass, bool isModified)
    {
        _deflectorClass = deflectorClass;
        _isEnable = false;
        _isModified = isModified;
    }

    public uint SmallAsteroidCounter { get; init; }
    public uint BigAsteroidCounter { get; init; }

    public void TakeDamage(AsteroidClass asteroidClass)
    {
        const uint oneAsteroidNumber = 1;

        if (asteroidClass == AsteroidClass.Small)
        {
            IncrementSmallAsteroidCounter(oneAsteroidNumber);
        }
        else
        {
            IncrementBigAsteroidCounter(oneAsteroidNumber);
        }
    }

    private void CheckDeflectorState()
    {
        if (IsAsteroidsDestroyDeflector())
        {
            _isEnable = false;
        }
    }

    private bool IsAsteroidsDestroyDeflector()
    {
        const uint class1DeflectorCapacitySmallAsteroids = 2;
        const uint class1DeflectorCapacityBigAsteroids = 1;

        const uint class2DeflectorCapacitySmallAsteroids = 10;
        const uint class2DeflectorCapacityBigAsteroids = 3;

        const uint class3DeflectorCapacitySmallAsteroids = 40;
        const uint class3DeflectorCapacityBigAsteroids = 10;

        switch (_deflectorClass)
        {
            case DeflectorClass.Class1:
                if (_smallAsteroidCounter == class1DeflectorCapacitySmallAsteroids || _bigAsteroidCounter == class1DeflectorCapacityBigAsteroids)
                {
                    return true;
                }

                break;
            case DeflectorClass.Class2:
                if (_smallAsteroidCounter == class2DeflectorCapacitySmallAsteroids || _bigAsteroidCounter == class2DeflectorCapacityBigAsteroids)
                {
                    return true;
                }

                break;

            // place for space whale!!!!
            case DeflectorClass.Class3:
                if (_smallAsteroidCounter == class3DeflectorCapacitySmallAsteroids || _bigAsteroidCounter == class3DeflectorCapacityBigAsteroids)
                {
                    return true;
                }

                break;
            default:
                return false;
        }

        return false;
    }

    private void IncrementSmallAsteroidCounter(uint incrementNumber)
    {
        if (_isEnable)
        {
            _smallAsteroidCounter += incrementNumber;
        }

        CheckDeflectorState();
    }

    private void IncrementBigAsteroidCounter(uint incrementNumber)
    {
        if (_isEnable)
        {
            _bigAsteroidCounter += incrementNumber;
        }

        CheckDeflectorState();
    }
}