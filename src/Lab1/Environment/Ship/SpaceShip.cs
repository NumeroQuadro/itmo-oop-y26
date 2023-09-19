namespace Itmo.ObjectOrientedProgramming.Lab1;

public class SpaceShip
{
    private readonly Deflector.Deflector _shipDeflector;
    public SpaceShip(Deflector.Deflector deflector)
    {
        _shipDeflector = deflector;
    }
}