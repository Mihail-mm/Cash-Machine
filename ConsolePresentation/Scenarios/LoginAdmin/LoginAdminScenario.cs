using Application.Contracts.Admins;
using Console;
using Models.ResultTypes;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.LoginAdmin;

public class LoginAdminScenario : IScenario
{
    private readonly IAdminService _adminService;

    public LoginAdminScenario(IAdminService adminService)
    {
        _adminService = adminService;
    }

    public string Name => "Login as Admin";

    public void Run()
    {
        string password = AnsiConsole.Ask<string>("Enter your Password");

        LoginResult result = _adminService.Login(password);

        string message = result switch
        {
            LoginResult.Success => "Successful login",
            LoginResult.NotFound => "Incorrect Password",
            _ => throw new ArgumentOutOfRangeException(nameof(result)),
        };

        AnsiConsole.WriteLine(message);
        AnsiConsole.Ask<string>("Enter any key to continue... ");
    }
}