using Application.Contracts.Admins;
using Console;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.LogoutAdmin;

public class LogoutAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LogoutAdminScenario(IAdminService service)
    {
        _adminService = service;
    }

    public string Name => "Logout";
    public void Run()
    {
        _adminService.Logout();
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}