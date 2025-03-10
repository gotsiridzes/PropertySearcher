using System.Runtime.Serialization;

namespace PropertyDataTester.MyHomeApi.GetStatements.Models;

public enum OwnerType : byte
{
	[EnumMember(Value = "physical")] 
	Physical,

    [EnumMember(Value = "developer")]
    Developer,

    [EnumMember(Value = "agent")]
    Agent
}