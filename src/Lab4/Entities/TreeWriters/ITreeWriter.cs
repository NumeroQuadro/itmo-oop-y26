using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface ITreeWriter
{
    public void DisplayTreeItem(IEnumerable<string> items);
}