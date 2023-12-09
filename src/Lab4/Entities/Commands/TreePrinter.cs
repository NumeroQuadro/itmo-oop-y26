using System;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreePrinter
{
    private Collection<string> _treeContent;

    public TreePrinter(Collection<string> treeContent)
    {
        _treeContent = treeContent;
    }

    public void Print()
    {
        foreach (string line in _treeContent)
        {
            Console.WriteLine(line);
        }
    }
}