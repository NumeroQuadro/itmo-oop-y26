namespace Lab5.Application.Models.Users;

public record User(long Id, string Username, UserType Type, string Password);