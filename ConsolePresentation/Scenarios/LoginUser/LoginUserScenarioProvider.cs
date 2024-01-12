using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Admins;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.LoginUser;

public class LoginUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _userService;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAdminService _currentAdmin;

    public LoginUserScenarioProvider(IUserService userService, ICurrentUserService currentUser, ICurrentAdminService currentAdmin)
    {
        _userService = userService;
        _currentUser = currentUser;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is null && _currentAdmin.Admin is null)
        {
            scenario = new LoginUserScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}