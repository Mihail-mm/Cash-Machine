using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.ReplenishAccount;

public class ReplenishAccountScenarioProvider : IScenarioProvider
{
    private readonly IUserService _service;
    private readonly ICurrentUserService _currentUser;

    public ReplenishAccountScenarioProvider(IUserService service, ICurrentUserService currentUser)
    {
        _service = service;
        _currentUser = currentUser;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = new ReplenishAccountScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}