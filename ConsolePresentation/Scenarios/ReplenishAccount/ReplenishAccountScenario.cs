using Application.Contracts.Users;
using Console;
using Models.ResultTypes;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.ReplenishAccount;

public class ReplenishAccountScenario : IScenario
{
    private readonly IUserService _userService;

    public ReplenishAccountScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Replenish Account";

    public void Run()
    {
        int amountDeposit = AnsiConsole.Ask<int>("Enter the amount you wish to deposit");

        ReplenishResults result = _userService.Replenish(amountDeposit);
        string message = result switch
        {
            ReplenishResults.Success => "Success",
            ReplenishResults.Failed => "Error",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}