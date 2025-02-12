using System.Runtime.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public enum OwnerType
{
	[EnumMember(Value = "physical")] Physical,
	Developer,
	Agent
}