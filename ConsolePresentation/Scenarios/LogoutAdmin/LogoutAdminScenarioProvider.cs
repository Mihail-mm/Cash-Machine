using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Admins;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.LogoutAdmin;

public class LogoutAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentUserService _currentUser;
    private readonly ICurrentAdminService _currentAdmin;

    public LogoutAdminScenarioProvider(IAdminService service, ICurrentUserService currentUser, ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentUser = currentUser;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        if (_currentAdmin.Admin is null)
        {
            scenario = null;
            return false;
        }

        scenario = new LogoutAdminScenario(_service);
        return true;
    }
}