using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Admins;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.LogoutUser;

public class LogoutUserScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAdminService _currentAdmin;

    public LogoutUserScenarioProvider(IUserService service, ICurrentUserService currentUser, ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentUser = currentUser;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            scenario = null;
            return false;
        }

        if (_currentUser.User is null)
        {
            scenario = null;
            return false;
        }

        scenario = new LogoutUserScenario(_service);
        return true;
    }
}