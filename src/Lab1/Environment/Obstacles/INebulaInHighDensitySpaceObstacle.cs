using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.Obstacles;

public interface INebulaInHighDensitySpaceObstacle : IObstacle
{
    public void DealDamage(ISpaceShuttle shuttle);
}