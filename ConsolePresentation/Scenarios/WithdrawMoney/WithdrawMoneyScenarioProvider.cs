using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Users;
using Console;

namespace ConsolePresentation.Scenarios.WithdrawMoney;

public class WithdrawMoneyScenarioProvider : IScenarioProvider
{
    private readonly ICurrentUserService _currentUser;
    private readonly IUserService _userService;

    public WithdrawMoneyScenarioProvider(ICurrentUserService currentUser, IUserService userService)
    {
        _currentUser = currentUser;
        _userService = userService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentUser.User is not null)
        {
            scenario = new WithdrawMoneyScenario(_userService);
            return true;
        }

        scenario = null;
        return false;
    }
}