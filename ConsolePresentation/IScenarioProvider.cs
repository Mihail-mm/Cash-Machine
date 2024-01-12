using System.Diagnostics.CodeAnalysis;

namespace Console;

public interface IScenarioProvider
{
    bool TryGetScenario([NotNullWhen(true)] out IScenario? scenario);
}