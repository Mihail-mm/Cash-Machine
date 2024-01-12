using Application.Contracts.Users;
using Console;
using Models.ResultTypes;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.LoginUser;

public class LoginUserScenario : IScenario
{
    private readonly IUserService _userService;

    public LoginUserScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Login as User";

    public void Run()
    {
        int accountNumber = AnsiConsole.Ask<int>("Enter your Account Number: ");
        int pinCode = AnsiConsole.Ask<int>("Enter your pin code: ");

        LoginResult result = _userService.Login(accountNumber, pinCode);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "User not found",
            LoginResult.WrongPinCode => "Wrong Pin Code",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Enter Any key to continue...");
    }
}