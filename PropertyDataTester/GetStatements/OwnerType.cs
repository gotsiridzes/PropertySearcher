using System.Runtime.Serialization;

namespace PropertyDataTester.GetStatements;

public enum OwnerType
{
	[EnumMember(Value = "physical")] Physical,
	Developer,
	Agent
}