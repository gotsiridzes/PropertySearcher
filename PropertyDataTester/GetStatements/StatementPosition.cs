namespace PropertyDataTester.GetStatements;

public record struct StatementPosition
{
	private StatementPosition(bool? notFirst, bool? notLast, bool? isLast)
	{
		NotFirst = notFirst;
		NotLast = notLast;
		IsLast = isLast;
	}

	public bool? NotFirst { get; }
	public bool? NotLast { get; }
	public bool? IsLast { get; }

	public static StatementPosition Create(bool? notFirst, bool? notLast, bool? isLast) =>
		new(notFirst, notLast, isLast);
}