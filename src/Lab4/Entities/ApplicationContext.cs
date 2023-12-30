using Itmo.ObjectOrientedProgramming.Lab4.Entities.FileSystems;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities;

public class ApplicationContext
{
    private TreeListWritingOptions _treeListWritingOptions;
    private IFileSystem? _fileSystem;

    public ApplicationContext(TreeListWritingOptions treeListWritingOptions)
    {
        _treeListWritingOptions = treeListWritingOptions;
    }

    public IFileSystem? FileSystem => _fileSystem;
    public TreeListWritingOptions TreeListWritingOptions => _treeListWritingOptions;

    public void WithFileSystem(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }
}