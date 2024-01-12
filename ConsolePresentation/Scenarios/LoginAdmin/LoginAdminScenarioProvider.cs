using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Admins;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.LoginAdmin;

public class LoginAdminScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _adminService;
    private readonly ICurrentAdminService _currentAdmin;
    private readonly ICurrentUserService _currentUser;

    public LoginAdminScenarioProvider(IAdminService adminService, ICurrentAdminService currentAdmin, ICurrentUserService currentUser)
    {
        _adminService = adminService;
        _currentAdmin = currentAdmin;
        _currentUser = currentUser;
    }

    public bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = null;
            return false;
        }

        if (_currentAdmin.Admin is not null)
        {
            scenario = null;
            return false;
        }

        scenario = new LoginAdminScenario(_adminService);
        return true;
    }
}