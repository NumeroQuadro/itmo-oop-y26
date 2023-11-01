namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers;

public class BlueModifier : IRenderableColorModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Blue(value);
    }
}