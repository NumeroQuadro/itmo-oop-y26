namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers;

public class RedColorModifier : IRenderableColorModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Red(value);
    }
}