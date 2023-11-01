using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3;

public static class Program
{
    public static void Main()
    {
        var item = new TextItem("dimon", new[] { new BlueModifier() });
        var printer = new ItemPrinter(item);
        printer.Print();
    }
}