using Application.Contracts.Users;
using Console;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.LogoutUser;

public class LogoutUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LogoutUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Logout";
    public void Run()
    {
        _userService.Logout();
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}