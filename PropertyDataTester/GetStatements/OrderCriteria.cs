namespace PropertyDataTester.GetStatements;

public readonly struct OrderCriteria
{
	public OrderByField Field { get; }
	public OrderSequence Sequence { get; }

	internal OrderCriteria(OrderByField field, OrderSequence sequence)
	{
		Field = field;
		Sequence = sequence;
	}

	public override string ToString() => $"{Field.ToString().ToLower()}_{Sequence.ToString().ToLower()}";
}