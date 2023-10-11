using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.EnvironmentTypes;

public interface IEnvironment
{
    public uint Length { get; }
    public SpaceTravelResult TakeOverTheShip(ISpaceShuttle shuttle);
    public bool IsShuttlePossibleToStayInCurrentEnvironment(ISpaceShuttle shuttle);
}