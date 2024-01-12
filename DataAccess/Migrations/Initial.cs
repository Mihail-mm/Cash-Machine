using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
    """
    create type operation_type as enum
    (
        'increase',
        'decrease'
    );
    
    create table users
    (
        id bigint primary key generated always as identity ,
        account_number int not null ,
        pin_code int not null ,
        user_money int not null 
    );

    INSERT INTO users (account_number, pin_code, user_money) VALUES (12345, 123, 0);

    create table admins
    (
        id bigint primary key generated always as identity ,
        password text not null 
    );

    INSERT INTO admins (password) VALUES (12345);

    create table operations
    (
        operations_id bigint primary key generated always as identity ,
        account_number int not null ,
        operation_type operation_type not null ,
        money int not null
    );
    """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
    """
    drop table users;
    drop table admins;
    drop table operatios;
    drop table operation_type;
    """;
}