using System.Collections.Generic;
using System.Data;
using GammaCore.Extensions;
using GammaCore.Samples.Extensions461;

namespace GammaCore.Test.Extensions461
{
	public class TestsBaseClass
	{
		protected List<TestingClass> GetList()
		{
			var testEnum = new List<TestingClass>();

			for (int i = 0; i < 50; i++)
			{
				testEnum.Add(new TestingClass
				{
					Key = i.ToString(),
					Value = i.ToString("000")
				});
			}
			return testEnum;
		}

		protected DataTable PrepareDataTable()
		{
			return GetList().ToDataTable();
		}
	}
}
