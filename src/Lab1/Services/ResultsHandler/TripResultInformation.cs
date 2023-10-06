using Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.ResultsHandler;

public sealed record TripResultInformation(SpaceTravelResult TravelResult, double BurnedActivePlasmaFuel, double BurnedGravitonFuel, double TraveledTime);