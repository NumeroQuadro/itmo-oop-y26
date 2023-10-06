namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement.SpaceTravelResults;

public sealed record Success(double BurnedActivePlasmaFuel, double BurnedGravitonFuel, double TraveledTime) : SpaceTravelResult(BurnedActivePlasmaFuel, BurnedGravitonFuel, TraveledTime);