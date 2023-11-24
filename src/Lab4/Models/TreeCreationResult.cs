using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Entities.Directory.DirectoryItems;

namespace Itmo.ObjectOrientedProgramming.Lab4.Models;

public abstract record TreeCreationResult
{
    private TreeCreationResult() { }

    public sealed record TreeCreatedSuccessfully(IEnumerable<DirectoryItem> Items) : TreeCreationResult;

    public sealed record TreeCreationFailed(string FailureMessage) : TreeCreationResult;
}