using Application.Contracts.Users;
using Console;
using Models;
using Spectre.Console;

namespace ConsolePresentation.Scenarios.OperationHistory;

public class OperationHistoryScenario : IScenario
{
    private readonly IUserService _userService;

    public OperationHistoryScenario(IUserService userService)
    {
        _userService = userService;
    }

    public string Name => "Operation History";

    public void Run()
    {
        IEnumerable<Operation> operations = _userService.ShowHistory();
        foreach (Operation operation in operations)
        {
            AnsiConsole.WriteLine(operation.ToString() ?? string.Empty);
        }

        AnsiConsole.Ask<string>("Enter any key to continue");
    }
}