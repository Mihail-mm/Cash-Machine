namespace Models.ResultTypes;

public abstract record WithdrawalsResults
{
    private WithdrawalsResults() { }
    public sealed record Success() : WithdrawalsResults;

    public sealed record Failed() : WithdrawalsResults;
}