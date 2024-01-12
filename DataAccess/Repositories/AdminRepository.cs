using Abstractions.Repositories;
using Itmo.Dev.Platform.Postgres.Connection;
using Itmo.Dev.Platform.Postgres.Extensions;
using Models;
using Npgsql;

namespace DataAccess.Repositories;

public class AdminRepository : IAdminRepository
{
    private const int NewUserBalance = 0;
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AdminRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public async Task<Admin?> FindAdminByAdminName(string password)
    {
        const string sql = """
                           select password
                           from admins
                           where password = :password;
                           """;

        NpgsqlConnection connectionAsync =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connectionAsync);
        command.AddParameter("password", password);

        using NpgsqlDataReader reader = await command.ExecuteReaderAsync().ConfigureAwait(false);

        if (await reader.ReadAsync().ConfigureAwait(false) is false)
            return null;

        return new Admin(
            Password: reader.GetString(0));
    }

    public async void AddUser(long accountNumber, int pinCode)
    {
        const string sql = """
                           INSERT INTO 
                           users (account_number, pin_code, user_money) 
                           VALUES (:accountNumber, :pinCode, :newUserBalance)
                           """;
        NpgsqlConnection connectionAsync =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connectionAsync);
        command.AddParameter("accountNumber", accountNumber);
        command.AddParameter("pinCode", pinCode);
        command.AddParameter("newUserBalance", NewUserBalance);
        command.ExecuteNonQuery();
    }

    public async void ChangePassword(string newPassword)
    {
        const string sql = """
                           UPDATE admins 
                           SET password = :newPassword;
                           """;
        NpgsqlConnection connectionAsync =
            await _connectionProvider.GetConnectionAsync(default).ConfigureAwait(false);
        using var command = new NpgsqlCommand(sql, connectionAsync);
        command.AddParameter("newPassword", newPassword);
        command.ExecuteNonQuery();
    }
}