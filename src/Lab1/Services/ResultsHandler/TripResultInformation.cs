using Itmo.ObjectOrientedProgramming.Lab1.Entities.Environment.SpaceMovement;
using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

public sealed record TripResultInformation(ISpaceShuttle Shuttle, SpaceTravelResult TravelResult, double Cost, double TraveledTime);