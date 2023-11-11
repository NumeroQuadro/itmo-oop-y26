using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public interface IDisplayDriver
{
    public void Clear();
    public void Print(string value);
    public string Modify(string value, IRenderableColorModifier modifier);
}