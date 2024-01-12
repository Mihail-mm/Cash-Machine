using Application.Contracts.Admins;
using Console;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.AddUser;

public class AddUserScenario : IScenario
{
    private readonly IAdminService _adminService;

    public AddUserScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Add new User";
    public void Run()
    {
        long userAccountNumber = AnsiConsole.Ask<long>("Enter account number for new user ");
        int userPinCode = AnsiConsole.Ask<int>("Enter pin code for new user ");
        _adminService.AddUser(userAccountNumber, userPinCode);
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}