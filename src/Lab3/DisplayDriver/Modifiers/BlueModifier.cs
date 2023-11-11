using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers;

public class BlueModifier : IRenderableColorModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Blue(value);
    }
}