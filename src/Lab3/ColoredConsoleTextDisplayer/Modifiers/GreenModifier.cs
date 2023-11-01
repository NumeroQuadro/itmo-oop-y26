namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers;

public class GreenModifier : IRenderableColorModifier
{
    public string Modify(string value)
    {
        return Crayon.Output.Green(value);
    }
}