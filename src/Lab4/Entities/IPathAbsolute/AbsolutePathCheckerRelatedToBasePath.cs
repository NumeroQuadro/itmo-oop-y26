using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.IPathAbsolute;

public class AbsolutePathCheckerRelatedToBasePath : IPathAbsoluteChecker
{
    public bool IsAbsolute(string basePath, string path)
    {
        string combinedPath = Path.Combine(basePath, path);

        return Path.GetFullPath(combinedPath).Equals(Path.GetFullPath(basePath), System.StringComparison.Ordinal);
    }
}