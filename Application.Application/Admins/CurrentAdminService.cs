using Application.Contracts.Admins;
using Models;

namespace Application.Application.Admins;

public class CurrentAdminService : ICurrentAdminService
{
    public Admin? Admin { get; set; }
}