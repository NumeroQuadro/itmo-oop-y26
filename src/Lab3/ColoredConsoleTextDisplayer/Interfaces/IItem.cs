using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public interface IItem : IRenderable
{
    IItem Clone();
    IItem AddModifier(IRenderableColorModifier modifier);
}