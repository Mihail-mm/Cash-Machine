namespace Models.ResultTypes;

public abstract record ReplenishResults
{
    private ReplenishResults() { }
    public sealed record Success() : ReplenishResults;

    public sealed record Failed() : ReplenishResults;
}