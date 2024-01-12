namespace Models;

public record User()
{
    public User(long accountNumber, int pinCode, int balance)
        : this()
    {
        AccountNumber = accountNumber;
        PinCode = pinCode;
        Balance = balance;
    }

    public long AccountNumber { get; set; }
    public int PinCode { get; set; }
    public int Balance { get; set; }
}