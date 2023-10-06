namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public sealed record ImpossibleToGoToEnvironment(double BurnedActivePlasmaFuel, double BurnedGravitonFuel, double TraveledTime) : SpaceTravelResult(BurnedActivePlasmaFuel, BurnedGravitonFuel, TraveledTime);