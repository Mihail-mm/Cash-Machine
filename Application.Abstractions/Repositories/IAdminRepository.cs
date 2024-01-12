using Models;

namespace Abstractions.Repositories;

public interface IAdminRepository
{
    Task<Admin?> FindAdminByAdminName(string password);
    void AddUser(long accountNumber, int pinCode);
    void ChangePassword(string newPassword);
}