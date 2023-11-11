using Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver.Modifiers.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDriver;

public interface IDisplayDriver
{
    public void Clear();
    public void Print(string value);
    public string Modify(string value, IRenderableColorModifier modifier);
}