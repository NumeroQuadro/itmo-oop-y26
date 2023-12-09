using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

public interface IResultsComparator
{
    public ISpaceShuttle GetShipWithBestResult();
}