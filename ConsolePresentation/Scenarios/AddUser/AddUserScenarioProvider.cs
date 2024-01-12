using System.Diagnostics.CodeAnalysis;
using Application.Contracts.Admins;
using Console;

namespace ConsolePresentation.Scenarios.AddUser;

public class AddUserScenarioProvider : IScenarioProvider
{
    private readonly IAdminService _service;
    private readonly ICurrentAdminService _currentAdmin;

    public AddUserScenarioProvider(IAdminService service, ICurrentAdminService currentAdmin)
    {
        _service = service;
        _currentAdmin = currentAdmin;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAdmin.Admin is not null)
        {
            scenario = new AddUserScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}