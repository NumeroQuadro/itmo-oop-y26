using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers;

public class GreenModifier : IRenderableColorModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Green(value);
    }
}