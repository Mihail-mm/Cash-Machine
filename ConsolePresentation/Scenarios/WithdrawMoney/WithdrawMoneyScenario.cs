using Application.Contracts.Users;
using Console;
using Models.ResultTypes;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenario : IScenario
{
    private readonly IUserService _userService;

    public WithdrawMoneyScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Withdraw Money";
    public void Run()
    {
        int withdrawals = AnsiConsole.Ask<int>("How much money you want to withdraw from your account ");
        WithdrawalsResults result = _userService.WithdrawMoney(withdrawals);
        string message = result switch
        {
            WithdrawalsResults.Success => "The withdrawal was successful",
            WithdrawalsResults.Failed => "Not enough money",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}