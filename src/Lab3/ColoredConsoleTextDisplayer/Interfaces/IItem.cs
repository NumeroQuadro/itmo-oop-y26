using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Interfaces;

public interface IItem : IRenderable
{
    IItem Clone();
    IItem AddModifier(IRenderableColorModifier modifier);
}