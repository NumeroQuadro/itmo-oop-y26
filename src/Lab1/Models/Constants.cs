namespace Itmo.ObjectOrientedProgramming.Lab1.Models;

public static class Constants
{
    public static double AsteroidDamage => 5.0;
    public static double MeteorDamage => 10.0;
    public static double DustingOfAntimatterDamage => 1000;
    public static double SpaceWhaleDamage => 150.0;

    // Engine specs
    public static double CClassImpulseEngineStartFuelConsumption => 10.0;
    public static double EClassImpulseEngineStartFuelConsumption => 15.0;
    public static double JumpEngineStartFuelConsumption => 20.0;
    public static double CClassImpulseEngineVelocity => 45.0;
    public static double EClassImpulseEngineVelocity => 65.0;
    public static double AlphaJumpEngineMaximalDistance => 5;
    public static double OmegaJumpEngineMaximalDistance => 10;
    public static double GammaJumpEngineMaximalDistance => 20;
    public static double AlphaJumpEngineVelocity => 100;
    public static double OmegaJumpEngineVelocity => 200;
    public static double GammaJumpEngineVelocity => 300;
    public static double PriceForActivePlasmaFuel => 23;
    public static double PriceForGravitonFuel => 56;

    // ShipHull specs
    public static double AClassShipHullHitPoints => 10.0;
    public static double BClassShipHullHitPoints => 30.0;
    public static double CClassShipHullHitPoints => 100.0;

    // Deflector specs
    public static double AClassDeflectorHitPoints => 20.0;
    public static double BClassDeflectorHitPoints => 50.0;
    public static double CClassDeflectorHitPoints => 150.0;

    // Dusting of antimatter reduce coefficients
    public static double AClassDeflectorDustingAntiMatterDamageReduceCoefficient => 0.007;
    public static double BClassDeflectorDustingAntiMatterDamageReduceCoefficient => 0.017;
    public static double CClassDeflectorDustingAntiMatterDamageReduceCoefficient => 0.050;
}