using Models.ResultTypes;

namespace Application.Contracts.Admins;

public interface IAdminService
{
    LoginResult Login(string adminName);
    void AddUser(long accountNumber, int pinCode);
    void ChangePassword(string newPassword);
    void Logout();
}