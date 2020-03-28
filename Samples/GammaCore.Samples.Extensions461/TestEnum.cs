using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GammaCore.Samples.Extensions461
{
	public enum TestEnum
	{
		Test01 = 100,
		Test02 = 200,
		Test03 = 300,
	}

	public enum TestEnumWithDisplayAttribute
	{
		[Display(Name = "Test 01")]
		Test01 = 100,
		[Display(Name = "Test 02")]
		Test02 = 200,
		[Display(Name = "Test 03")]
		Test03 = 300,
	}

	public enum TestEnumWithDescriptionAttribute
	{
		[Description(description: "Test 01")]
		Test01 = 100,
		[Description(description: "Test 02")]
		Test02 = 200,
		[Description(description: "Test 03")]
		Test03 = 300,
	}
}
