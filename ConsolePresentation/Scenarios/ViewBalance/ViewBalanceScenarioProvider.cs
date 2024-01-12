using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.ViewBalance;

public class ViewBalanceScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ViewBalanceScenarioProvider(
        IUserService service,
        ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = new ViewBalanceScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}