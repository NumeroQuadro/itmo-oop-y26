namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public class DustingOfAntiMatter : INebulaInHighDensitySpaceObstacle
{
    private readonly uint _maxDustingAntiMatterCounter;
    private uint _hitPoints;
    public DustingOfAntiMatter(uint maxDustingAntiMatterCounter)
    {
        _maxDustingAntiMatterCounter = maxDustingAntiMatterCounter;
    }
}