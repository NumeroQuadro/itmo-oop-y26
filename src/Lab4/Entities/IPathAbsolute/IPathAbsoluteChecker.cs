namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.IPathAbsolute;

public interface IPathAbsoluteChecker
{
    public bool IsAbsolute(string basePath, string path);
}