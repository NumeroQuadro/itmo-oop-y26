using Itmo.ObjectOrientedProgramming.Lab4.Entities.AppStateInformation.AppStateInitial;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.CommandContexts.TreeListContext;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryTreeCreators;
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

    public CommandExecutionResult Execute(FileSystemContext fileSystemContext)
    {
        IDirectory? currentPathDirectory = fileSystemContext.Directory;
        var treeCreator = new DirectoryItemsTreeCreator();
        TreeCreationResult result = treeCreator.Create(fileSystemContext, currentPathDirectory);

        if (result is TreeCreationResult.TreeCreatedSuccessfully)
        {
            return new CommandExecutionResult.ExecutedSuccessfully("tree list was created successfully");
        }

        return new CommandExecutionResult.ExecutedWithFailure("tree list creation failed");
    }
}