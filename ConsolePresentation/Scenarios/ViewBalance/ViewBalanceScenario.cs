using System.Globalization;
using Application.Contracts.Users;
using Console;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.ViewBalance;

public class ViewBalanceScenario : IScenario
{
    private readonly IUserService _userService;

    public ViewBalanceScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "View Balance";

    public void Run()
    {
        int result = _userService.ViewBalance();
        AnsiConsole.WriteLine(NumberFormatInfo.CurrentInfo, result);
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}