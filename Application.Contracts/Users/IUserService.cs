using Models;
using Models.ResultTypes;

namespace Application.Contracts.Users;

public interface IUserService
{
    LoginResult Login(long accountNumber, int pinCode);
    void Logout();
    int ViewBalance();
    ReplenishResults Replenish(int amountDeposit);
    WithdrawalsResults WithdrawMoney(int withdrawals);
    IEnumerable<Operation> ShowHistory();
}