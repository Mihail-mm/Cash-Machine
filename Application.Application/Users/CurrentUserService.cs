using Application.Contracts.Users;
using Models;

namespace Application.Application.Users;

public class CurrentUserService : ICurrentUserService
{
    public User? User { get; set; }
}