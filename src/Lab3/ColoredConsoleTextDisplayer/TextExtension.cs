using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public static class TextExtension
{
    public static IItem WithModifier<T>(
        T text,
        IRenderableColorModifier colorModifier)
        where T : IItem
    {
        IItem clone = text.Clone();
        clone.AddModifier(colorModifier);

        return clone;
    }
}