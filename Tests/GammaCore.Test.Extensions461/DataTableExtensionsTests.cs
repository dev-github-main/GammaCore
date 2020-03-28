using System;
using GammaCore.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GammaCore.Test.Extensions461
{
	[TestClass]
	public class DataTableExtensionsTests : TestsBaseClass
	{
		[TestMethod]
		public void ToCsv_Return_Csv_From_DataTable()
		{
			var dataTable = PrepareDataTable();

			var result = dataTable.ToCsv();

			Assert.AreEqual("Value;Key", ReadRow(result, 0));
			Assert.AreEqual("\"010\";\"10\"", ReadRow(result, 11));
			Assert.AreEqual("\"030\";\"30\"", ReadRow(result, 31));
		}

		private string ReadRow(string text, int rowIndex)
		{
			string[] rows = text.Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			return rows[rowIndex];
		}
	}
}
