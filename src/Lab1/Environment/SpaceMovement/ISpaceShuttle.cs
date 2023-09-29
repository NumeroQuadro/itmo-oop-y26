using Itmo.ObjectOrientedProgramming.Lab1.Environment.EnvironmentTypes;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public interface ISpaceShuttle : IFly
{
    protected bool IsPossibleToStayInHighDensitySpace();
    protected bool IsPossibleToStayInSpace();
    protected bool IsPossibleToStayInNitrinoParticleNebula();
    public IEnvironment CurrentEnvironment { get; init; }
    public uint HitPoints { get; }
    public bool IsDeflectorDestroyed();
    public (uint, uint) GetDeflectorCounter();
    public (uint, uint) GetShipHullCounters();
    public void DestroyShuttle();
    public bool IsDestroyed { get; }
    public void ShipHullTakeDamage();
    public void DeflectorTakeDamage();
}