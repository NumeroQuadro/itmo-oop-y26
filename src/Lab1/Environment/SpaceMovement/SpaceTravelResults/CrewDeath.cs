namespace Itmo.ObjectOrientedProgramming.Lab1.Environment.SpaceMovement;

public sealed record CrewDeath(double BurnedActivePlasmaFuel, double BurnedGravitonFuel, double TraveledTime) : SpaceTravelResult(BurnedActivePlasmaFuel, BurnedGravitonFuel, TraveledTime);