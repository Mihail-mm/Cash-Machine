namespace Models.ResultTypes;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success : LoginResult;

    public sealed record NotFound : LoginResult;

    public sealed record WrongPinCode : LoginResult;
}