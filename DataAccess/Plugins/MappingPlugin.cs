using Itmo.Dev.Platform.Postgres.Plugins;
using Models;
using Npgsql;

namespace DataAccess.Plugins;

public class MappingPlugin : IDataSourcePlugin
{
    public void Configure(NpgsqlDataSourceBuilder builder)
    {
        builder.MapEnum<OperationType>();
    }
}