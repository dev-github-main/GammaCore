using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using GammaCore.Extensions;
using GammaCore.Samples.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GammaCore.Test.Extensions
{
	[TestClass]
	public class AssemblyExtensionsTests
	{
		[TestMethod]
		public void GetAttributes_Return_Attributes_List()
		{
			Assembly assembly = typeof(TestingClass).Assembly;

			var attribs = assembly.GetAttributes<GuidAttribute>();
			Guid guid = Guid.Parse(attribs.First().Value);

			Assert.AreEqual(Guid.Parse("b34b5262-3d0c-4fdd-a35b-e0f260e56a27"), guid);
		}
	}
}
