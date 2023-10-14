using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public interface IEnvironment
{
    public int Length { get; }
    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle);
    public bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle);
}