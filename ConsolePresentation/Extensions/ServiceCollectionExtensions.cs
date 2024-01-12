using ConsolePresentation;
using ConsolePresentation.Scenarios.AddUser;
using ConsolePresentation.Scenarios.ChangeAdminPassword;
using ConsolePresentation.Scenarios.LoginAdmin;
using ConsolePresentation.Scenarios.LoginUser;
using ConsolePresentation.Scenarios.LogoutAdmin;
using ConsolePresentation.Scenarios.LogoutUser;
using ConsolePresentation.Scenarios.OperationHistory;
using ConsolePresentation.Scenarios.ReplenishAccount;
using ConsolePresentation.Scenarios.ViewBalance;
using ConsolePresentation.Scenarios.WithdrawMoney;
using Microsoft.Extensions.DependencyInjection;

namespace Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LoginAdminScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ViewBalanceScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ReplenishAccountScenarioProvider>();
        collection.AddScoped<IScenarioProvider, WithdrawMoneyScenarioProvider>();
        collection.AddScoped<IScenarioProvider, AddUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, ChangeAdminPasswordScenarioProvider>();
        collection.AddScoped<IScenarioProvider, OperationHistoryScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutUserScenarioProvider>();
        collection.AddScoped<IScenarioProvider, LogoutAdminScenarioProvider>();

        return collection;
    }
}