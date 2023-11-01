using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer.Modifiers;

namespace Itmo.ObjectOrientedProgramming.Lab3.ColoredConsoleTextDisplayer;

public class TextItem : IItem
{
    private readonly string _content;
    private readonly List<IRenderableColorModifier> _modifiers;

    public TextItem(string textContent)
    {
        _content = textContent;
        _modifiers = new List<IRenderableColorModifier>();
    }

    public TextItem(string content, IEnumerable<IRenderableColorModifier> modifiers)
    {
        _content = content;
        _modifiers = new List<IRenderableColorModifier>(modifiers);
    }

    public string Content => _content;

    public IItem Clone()
    {
        return new TextItem(Content, _modifiers);
    }

    public IItem AddModifier(IRenderableColorModifier modifier)
    {
        _modifiers.Add(modifier);

        return this;
    }

    public string Render()
    {
        return _modifiers.Aggregate(Content, (c, m) => m.Modify(c));
    }
}