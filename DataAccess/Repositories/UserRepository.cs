using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models;
using Npgsql;

namespace DataAccess.Repositories;

public class UserRepository : IUserRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public UserRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<User?> FindUserByAccountNumber(long accountNumber)
    {
        const string sql = """
                           select account_number, pin_code, user_money 
                           from users 
                           where account_number = :accountNumber;
                           """;

        NpgsqlConnection connectionAsync =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connectionAsync);
        command.AddParameter("accountNumber", accountNumber);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return new User(
            reader.GetInt32(0),
            reader.GetInt32(1),
            reader.GetInt32(2));
    }

    public async void UpdateMoney(long accountNumber, int newMoney)
    {
        const string sql = """
                           UPDATE users 
                           SET user_money = :newMoney 
                           where account_number = :accountNumber;
                           """;
        NpgsqlConnection connectionAsync =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connectionAsync);
        command.AddParameter("newMoney", newMoney);
        command.AddParameter("accountNumber", accountNumber);
        command.ExecuteNonQuery();
    }

    public async IAsyncEnumerable<Operation> GetAllOperations(long accountNumber)
    {
        const string sql = """
                           SELECT operations_id, account_number, operation_type, money 
                           FROM operations 
                           WHERE account_number=:accountNumber 
                           ORDER BY operations_id 
                           """;
        NpgsqlConnection connection = await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connection);
        command.AddParameter("accountNumber", accountNumber);
        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);
        if (await reader.ReadAsync().ConfigureAwait(false) is false)
        {
            yield break;
        }

        while (await reader.ReadAsync().ConfigureAwait(false))
        {
            yield return new Operation(
                await reader.GetFieldValueAsync<OperationType>(2).ConfigureAwait(false),
                reader.GetInt32(3));
        }
    }

    public async void SaveOperation(long accountNumber, Operation operation)
    {
        const string sql = """INSERT INTO operations (account_number, operation_type, money) VALUES (:accountNumber, :operationType, :operationMoney)""";
        NpgsqlConnection connectionAsync =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connectionAsync);
        command.AddParameter("accountNumber", accountNumber);
        command.AddParameter("operationType", operation.Type);
        command.AddParameter("operationMoney", operation.Money);
        command.ExecuteNonQuery();
    }
}