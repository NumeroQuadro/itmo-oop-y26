using System;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.InformationConverter;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;

public class FileSystemContext
{
    private IDirectory? _absolutePath;
    private OperatingSystem _osPlatform;
    private IDirectory? _currentDirectory;
    private ConnectMode? _mode;
    private TreeListWritingOptions? _treeListWritingOptions;

    public FileSystemContext()
    {
        _osPlatform = Environment.OSVersion;
    }

    public IDirectory? Directory => _currentDirectory;
    public OperatingSystem? OsPlatform => _osPlatform;
    public IDirectory? AbsolutePath => _absolutePath;
    public ConnectMode? Mode => _mode;
    public TreeListWritingOptions? TreeListWritingOptions => _treeListWritingOptions;

    public void WithTreeListWritingOptions(string indentation, string directoryPrefix, string filePrefix)
    {
        _treeListWritingOptions = new TreeListWritingOptions(indentation, directoryPrefix, filePrefix);
    }

    public void WithAbsolutePath(string absolutePath)
    {
        var converter = new ConverterInfoRelatedToOperatingSystem(this);
        _absolutePath = converter.GetPathRelatedToSystem(absolutePath);
    }

    public void WithConnectMode(ConnectMode mode)
    {
        _mode = mode;
    }

    public void WithOsPlatform(OperatingSystem osPlatform)
    {
        _osPlatform = osPlatform;
    }

    public void WithCurrentDirectory(string currentDirectory)
    {
        var converter = new ConverterInfoRelatedToOperatingSystem(this);
        _currentDirectory = converter.GetPathRelatedToSystem(currentDirectory);
    }
}