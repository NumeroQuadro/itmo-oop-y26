using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create type user_type as enum
        (
            'Admin',
            'User',
        );
        
        CREATE TABLE Accounts
        (
            AccountId SERIAL PRIMARY KEY generated always as identity,
            UserID bigint not null references Users(UserID),
            Balance DECIMAL(18, 2) NOT NULL
        );

        CREATE TABLE Admins
        (
            AdminID SERIAL PRIMARY KEY generated always as identity,
            user_type user_type not null,
            Username text not null,
            Password VARCHAR(50) NOT NULL
        );
        
        CREATE TABLE Users
        (
            UserID SERIAL PRIMARY KEY generated always as identity,
            Username text not null,
            user_type user_type not null,
            Password VARCHAR(50) NOT NULL
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table if exists Accounts cascade;
        drop table if exists Admins cascade;
        drop table if exists Users cascade;

        drop type if exists user_role;
        """;
}