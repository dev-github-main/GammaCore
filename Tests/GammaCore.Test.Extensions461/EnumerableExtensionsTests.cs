using System.Data;
using System.Linq;
using GammaCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GammaCore.Test.Extensions461
{
	[TestClass]
	public class EnumerableExtensionsTests : TestsBaseClass
	{
		[TestMethod]
		public void ToDataTable_Return_DataTable_From_IEnumerable()
		{
			Assert.IsInstanceOfType(GetList().AsEnumerable().ToDataTable(), typeof(DataTable));
		}

		[TestMethod]
		public void ToDataTable_Return_DataTable_From_IList()
		{
			Assert.IsInstanceOfType(GetList().ToDataTable(), typeof(DataTable));
		}
	}
}
