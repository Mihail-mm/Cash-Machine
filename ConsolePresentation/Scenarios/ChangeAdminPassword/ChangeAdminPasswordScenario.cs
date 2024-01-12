using Application.Contracts.Admins;
using Console;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.ChangeAdminPassword;

public class ChangeAdminPasswordScenario : IScenario
{
    private readonly IAdminService _adminService;

    public ChangeAdminPasswordScenario(IAdminService service)
    {
        _adminService = service;
    }

    public string Name => "Change Password";
    public void Run()
    {
        string newPassword = AnsiConsole.Ask<string>("Enter new password for admin");
        _adminService.ChangePassword(newPassword);
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}