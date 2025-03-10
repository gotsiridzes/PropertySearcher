namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public readonly record struct StatementPosition
{
    public static readonly StatementPosition NotFirstPosition = new(true, false, false);
    public static readonly StatementPosition NotLastPosition = new(false, true, false);

    private StatementPosition(
        bool notFirst,
        bool notLast,
        bool isLast)
    {
        NotFirst = notFirst;
        NotLast = notLast;
        IsLast = isLast;
    }

    public bool NotFirst { get; }
    public bool NotLast { get; }
    public bool IsLast { get; }
}