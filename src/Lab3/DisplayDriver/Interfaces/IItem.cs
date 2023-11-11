using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Interfaces;

public interface IItem : IRenderable
{
    IItem Clone();
    IItem AddModifier(IRenderableColorModifier modifier);
}