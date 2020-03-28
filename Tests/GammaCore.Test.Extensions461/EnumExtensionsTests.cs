using System.Collections.Generic;
using System.Linq;
using GammaCore.Extensions;
using GammaCore.Samples.Extensions461;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GammaCore.Test.Extensions461
{
	[TestClass]
	public class EnumExtensionsTests : TestsBaseClass
	{
		[TestMethod]
		public void GetDisplayValue_Return_Enum_Value()
		{
			string result = TestEnum.Test01.GetDisplayValue();

			Assert.AreEqual("Test01", result);
		}

		[TestMethod]
		public void GetDisplayValue_Return_DisplayAttribute_Value()
		{
			string result = TestEnumWithDisplayAttribute.Test01.GetDisplayValue();

			Assert.AreEqual("Test 01", result);
		}

		[TestMethod]
		public void GetDisplayValue_Return_DescriptionAttribute_Value()
		{
			string result = TestEnumWithDescriptionAttribute.Test01.GetDisplayValue();

			Assert.AreEqual("Test 01", result);
		}

		[TestMethod]
		public void ToDictionary_Return_Dictionary_From_Enum()
		{
			var result = typeof(TestEnum).ToDictionary();

			Assert.AreEqual(TestEnum.Test01.ToString(), result.Single(x => x.Key == 100).Value);
			Assert.AreEqual(TestEnum.Test02.ToString(), result.Single(x => x.Key == 200).Value);
			Assert.AreEqual(TestEnum.Test03.ToString(), result.Single(x => x.Key == 300).Value);
		}

		[TestMethod]
		public void ToDictionary_Return_DisplayAttribute_Value()
		{
			var result = typeof(TestEnumWithDisplayAttribute).ToDictionary();

			Assert.AreEqual(result.Single(x => x.Key == 100).Value, "Test 01");
			Assert.AreEqual(result.Single(x => x.Key == 200).Value, "Test 02");
			Assert.AreEqual(result.Single(x => x.Key == 300).Value, "Test 03");
		}

		[TestMethod]
		public void ToDictionary_Return_DescriptionAttribute_Value()
		{
			var result = typeof(TestEnumWithDescriptionAttribute).ToDictionary();

			Assert.AreEqual(result.Single(x => x.Key == 100).Value, "Test 01");
			Assert.AreEqual(result.Single(x => x.Key == 200).Value, "Test 02");
			Assert.AreEqual(result.Single(x => x.Key == 300).Value, "Test 03");
		}
	}
}
