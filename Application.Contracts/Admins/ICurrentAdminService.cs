using Models;

namespace Application.Contracts.Admins;

public interface ICurrentAdminService
{
    Admin? Admin { get; set; }
}