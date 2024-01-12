using Abstractions.Repositories;
using Application.Contracts.Admins;
using Models;
using Models.ResultTypes;

namespace Application.Application.Admins;

public class AdminService : IAdminService
{
    private readonly IAdminRepository _repository;
    private readonly ICurrentAdminService _currentAdminManager;

    public AdminService(IAdminRepository repository, ICurrentAdminService currentAdminManager)
    {
        _repository = repository;
        _currentAdminManager = currentAdminManager;
    }

    public LoginResult Login(string adminName)
    {
        Admin? admin = _repository.FindAdminByAdminName(adminName).Result;

        if (admin is null)
        {
            return new LoginResult.NotFound();
        }

        _currentAdminManager.Admin = admin;
        return new LoginResult.Success();
    }

    public void AddUser(long accountNumber, int pinCode)
    {
        _repository.AddUser(accountNumber, pinCode);
    }

    public void ChangePassword(string newPassword)
    {
        _repository.ChangePassword(newPassword);
    }

    public void Logout()
    {
        _currentAdminManager.Admin = null;
    }
}