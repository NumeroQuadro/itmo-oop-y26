namespace Itmo.ObjectOrientedProgramming.Lab1;

public static class Constants
{
    public static double AsteroidDamage { get; } = 5.0;
    public static double MeteorDamage { get; } = 10.0;
    public static double DustingOfAntimatterDamage { get; } = 15.0;

    // ShipHull specs
    public static double AClassShipHullHitPoints { get; } = 5.0;
    public static double AClassShipHullAsteroidDamageCoefficient { get; } = 5.0;
    public static double AClassSHipHullMeteorDamageCoefficient { get; } = 1.0;

    public static double BClassShipHullHitPoints { get; } = 45;
    public static double BClassShipHullAsteroidDamageCoefficient { get; } = 1.8;
    public static double BClassShipHUllMeteorDamageCoefficient { get; } = 2.25;

    public static double CClassShipHullHitPoints { get; } = 150.0;
    public static double CClassShipHullAsteroidDamageCoefficient { get; } = 1.5;
    public static double CClassShipHullMeteorDamageCoefficient { get; } = 3.0;

    // Deflector specs
    public static double AClassDeflectorWithoutPhotonModificationHitPoints { get; } = 20.0;
    public static double AClassDeflectorWithoutPhotonModificationAsteroidDamageCoefficient { get; } = 2.0;
    public static double AClassDeflectorWithoutPhotonModificationMeteorDamageCoefficient { get; } = 2.0;

    public static double AClassDeflectorWithPhotonModificationHitPoints { get; } = 65.0;
    public static double AClassDeflectorWithPhotonModificationAsteroidDamageCoefficient { get; } = 6.5;
    public static double AClassDeflectorWithPhotonModificationMeteorDamageCoefficient { get; } = 6.5;
    public static double AClassDeflectorWithPhotonModificationDustingOfAntiMatterDamageCoefficient { get; } = 1.44;

    public static double BClassDeflectorWithoutPhotonModificationHitPoints { get; } = 80;
    public static double BClassDeflectorWithoutPhotonModificationAsteroidDamageCoefficient { get; } = 1.6;
    public static double BClassDeflectorPhotonModificationEmitterMeteorDamageCoefficient { get; } = 2.66;

    public static double BClassDeflectorWithPhotonModificationHitPoints { get; } = 125;
    public static double BClassDeflectorWithPhotonModificationAsteroidDamageCoefficient { get; } = 1.5;
    public static double BClassDeflectorWithPhotonModificationMeteorDamageCoefficient { get; } = 4.16;
    public static double BClassDeflectorWithPhotonModificationDustingOfAntiMatterDamageCoefficient { get; } = 2.7;

    public static double CClassDeflectorWithoutPhotonModificationHitPoints { get; } = 300;
    public static double CClassDeflectorWithoutPhotonModificationAsteroidDamageCoefficient { get; } = 1.5;
    public static double CClassDeflectorWithoutPhotonModificationMeteorDamageCoefficient { get; } = 3.0;
    public static double CClassDeflectorWithoutPhotonModificationDustingOfAntiMatterDamageCoefficient { get; } = 7.66; // ???????????????????????????????/

    public static double CClassDeflectorWithPhotonModificationHitPoints { get; } = 345;
    public static double CClassDeflectorWithPhotonModificationAsteroidDamageCoefficient { get; } = 1.725;
    public static double CClassDeflectorWithPhotonModificationMeteorDamageCoefficient { get; } = 3.45;
    public static double CClassDeflectorWithPhotonModificationDustingOfAntiMatterDamageCoefficient { get; } = 7.66;
}