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

	public static StatementPosition Create(bool? notFirst, bool? notLast, bool? isLast)
	{
		Validate(notFirst, notLast, isLast);
		return new(notFirst, notLast, isLast);
	}

	private static void Validate(bool? notFirst, bool? notLast, bool? isLast)
	{
		if (isLast == true && (notFirst == true || notLast == true))
			throw new InvalidOperationException("'is_last' cannot be used with 'not_first' or 'not_last'.");

		if ((notFirst == true && notLast == true) || (notFirst == true && isLast == true) || isLast == true)
			return;

		throw new InvalidOperationException(
			"Invalid combination: Allowed (not_first, not_last), (not_first, is_last), or (is_last).");
	}
}