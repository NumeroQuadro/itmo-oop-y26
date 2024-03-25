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
                'User'
                );
        
        create type transaction_type as enum
            (
                'Deposit',
                'Withdraw'
                );
        
        CREATE TABLE Admins
        (
            AdminID bigint PRIMARY KEY generated always as identity,
            user_type user_type not null,
            Username VARCHAR(50) not null,
            Password VARCHAR(50) NOT NULL
        );
        
        CREATE TABLE Users
        (
            UserID bigint PRIMARY KEY generated always as identity,
            Username VARCHAR(50) not null,
            user_type user_type not null,
            Password VARCHAR(50) NOT NULL,
            Balance DECIMAL(18, 2) NOT NULL
        );
        
        CREATE TABLE TransactionHistory
        (
            TransactionID bigint PRIMARY KEY generated always as identity,
            Username VARCHAR(50) not null,
            transaction_type transaction_type not null,
            Amount DECIMAL(18, 2) not null
        );
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table if exists Admins cascade;
        drop table if exists Users cascade;
        drop table if exists TransactionHistory cascade;
        
        drop type if exists user_type cascade;
        drop type if exists transaction_type cascade;
        """;
}