using Itmo.ObjectOrientedProgramming.Lab1.Models.SpaceTravelResults;

namespace Itmo.ObjectOrientedProgramming.Lab1.Services.ResultsHandler;

public sealed record TripResultInformation(SpaceTravelResult TravelResult, double CostForBurnedActivePlasmaFuel, double CostForBurnedGravitonFuel, double TraveledTime);