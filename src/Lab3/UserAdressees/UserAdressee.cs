using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserAdressees;

public class UserAdressee : IAdressee
{
    private readonly User _user;

    public UserAdressee(User user)
    {
        _user = user;
    }

    public void GetMessage(Message message)
    {
        _user.GetMessage(message);
    }

    private static string ArgumentsToLogMessage()
    {
        return "User reveived message";
    }
}