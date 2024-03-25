using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayDrivers;

public interface IDisplayDriver
{
    public void Clear();
    public void Print(string value, ConsoleColor color);
}