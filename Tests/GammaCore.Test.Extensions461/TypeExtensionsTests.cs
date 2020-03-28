using GammaCore.Extensions;
using GammaCore.Samples.Extensions461;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GammaCore.Test.Extensions461
{
	[TestClass]
	public class TypeExtensionsTests
	{
		[TestMethod]
		public void IsAssignableToGenericType_Return_True()
		{
			Assert.IsTrue(typeof(TestingClass).IsAssignableToGenericType(typeof(BaseTestingClass)));
			Assert.IsTrue(typeof(TestingClass).IsAssignableToGenericType(typeof(IGenericType)));
			Assert.IsTrue(typeof(TestingClass).IsAssignableToGenericType(typeof(TestingClass)));
		}

		[TestMethod]
		public void IsAssignableToGenericType_Return_False()
		{
			Assert.IsFalse(typeof(TestEnum).IsAssignableToGenericType(typeof(BaseTestingClass)));
			Assert.IsFalse(typeof(TestEnum).IsAssignableToGenericType(typeof(IGenericType)));
			Assert.IsFalse(typeof(TestEnum).IsAssignableToGenericType(typeof(TestingClass)));
		}
	}
}
