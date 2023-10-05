namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Constants
{
    public static double AsteroidDamage { get; } = 5.0;
    public static double MeteorDamage { get; } = 10.0;
    public static double DustingOfAntimatterDamage { get; } = 1000;
    public static double SpaceWhaleDamage { get; } = 150.0;

    // Engine specs
    public static double CClassImpulseEngineStartFuelConsumption { get; } = 10.0;
    public static double EClassImpulseEngineStartFuelConsumption { get; } = 15.0;
    public static double CClassImpulseEngineVelocity { get; } = 45.0;
    public static double EClassImpulseEngineVelocity { get; } = 65.0;
    public static double JumpEngineStartFuelConsumption { get; } = 20.0;
    public static double AlphaJumpEngineVelocity { get; } = 100;
    public static double OmegaJumpEngineVelocity { get; } = 200;
    public static double GammaJumpEngineVelocity { get; } = 300;
    public static double PriceForActivePlasmaFuel { get; } = 23;
    public static double PriceForGravitonFuel { get; } = 56;

    // ShipHull specs
    public static double AClassShipHullHitPoints { get; } = 10.0;
    public static double BClassShipHullHitPoints { get; } = 30.0;
    public static double CClassShipHullHitPoints { get; } = 100.0;

    // Deflector specs
    public static double AClassDeflectorHitPoints { get; } = 20.0;
    public static double BClassDeflectorHitPoints { get; } = 50.0;
    public static double CClassDeflectorHitPoints { get; } = 150.0;

    // Dusting of antimatter reduce coefficients
    public static double AClassDeflectorDustingAntiMatterDamageReduceCoefficient { get; } = 0.007;
    public static double BClassDeflectorDustingAntiMatterDamageReduceCoefficient { get; } = 0.017;
    public static double CClassDeflectorDustingAntiMatterDamageReduceCoefficient { get; } = 0.050;
}