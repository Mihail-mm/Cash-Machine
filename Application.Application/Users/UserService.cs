using Abstractions.Repositories;
using Application.Contracts.Users;
using Models;
using Models.ResultTypes;

namespace Application.Application.Users;

public class UserService : IUserService
{
    private const int DefaultBalance = 0;
    private readonly IUserRepository _repository;
    private readonly ICurrentUserService _currentUserManager;

    public UserService(IUserRepository repository, ICurrentUserService currentUserManager)
    {
        _repository = repository;
        _currentUserManager = currentUserManager;
    }

    public LoginResult Login(long accountNumber, int pinCode)
    {
        User? user = _repository.FindUserByAccountNumber(accountNumber).Result;

        if (user is null)
        {
            return new LoginResult.NotFound();
        }

        if (user.PinCode != pinCode)
        {
            return new LoginResult.WrongPinCode();
        }

        _currentUserManager.User = user;
        return new LoginResult.Success();
    }

    public void Logout()
    {
        _currentUserManager.User = null;
    }

    public int ViewBalance()
    {
        if (_currentUserManager.User is null)
        {
            return DefaultBalance;
        }

        User? result = _repository.FindUserByAccountNumber(_currentUserManager.User.AccountNumber).Result;
        return result?.Balance ?? DefaultBalance;
    }

    public ReplenishResults Replenish(int amountDeposit)
    {
        if (amountDeposit < 0)
        {
            return new ReplenishResults.Failed();
        }

        if (_currentUserManager.User is not null)
        {
            _currentUserManager.User.Balance += amountDeposit;
            _repository.UpdateMoney(_currentUserManager.User.AccountNumber, _currentUserManager.User.Balance);
            _repository.SaveOperation(_currentUserManager.User.AccountNumber, new Operation(OperationType.Increase, amountDeposit));
        }

        return new ReplenishResults.Success();
    }

    public WithdrawalsResults WithdrawMoney(int withdrawals)
    {
        if (_currentUserManager.User?.Balance < withdrawals)
        {
            return new WithdrawalsResults.Failed();
        }

        if (_currentUserManager.User is not null)
        {
            _currentUserManager.User.Balance -= withdrawals;
            _repository.UpdateMoney(_currentUserManager.User.AccountNumber, _currentUserManager.User.Balance);
            _repository.SaveOperation(_currentUserManager.User.AccountNumber, new Operation(OperationType.Decrease, withdrawals));
        }

        return new WithdrawalsResults.Success();
    }

    public IEnumerable<Operation> ShowHistory()
    {
        if (_currentUserManager.User is not null)
        {
            return _repository.GetAllOperations(_currentUserManager.User.AccountNumber).ToBlockingEnumerable();
        }

        return new List<Operation>();
    }
}