using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.TreeCreators;
using Itmo.ObjectOrientedProgramming.Lab4.Models;

namespace Itmo.ObjectOrientedProgramming.Lab4.Entities.Commands;

public class TreeList : ICommand
{
    private TreeListContext _context;

    public TreeList(TreeListContext context)
    {
        _context = context;
    }

    public ICommandContext CommandContext => _context;

    public CommandExecutionResult Execute(ApplicationContext applicationContext)
    {
        if (applicationContext.FileSystem is null)
        {
            return new CommandExecutionResult.ExecutedWithFailure("File system is not initialized");
        }

        var creator = new TreeCreator(_context.Depth);

        FolderItem rootFolder = creator.BuildFileSystemTree(applicationContext.FileSystem.GetCurrentPath);

        const int startDepth = 0;
        var printer = new VisitorItemsExtractor();
        rootFolder.Accept(startDepth, applicationContext.TreeListWritingOptions, printer);

        return new CommandExecutionResult.ExecutedSuccessfully("tree list was printed");
    }
}