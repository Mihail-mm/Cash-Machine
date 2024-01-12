using Models;

namespace Abstractions.Repositories;

public interface IUserRepository
{
    Task<User?> FindUserByAccountNumber(long accountNumber);
    void UpdateMoney(long accountNumber, int newMoney);
    IAsyncEnumerable<Operation> GetAllOperations(long accountNumber);
    void SaveOperation(long accountNumber, Operation operation);
}