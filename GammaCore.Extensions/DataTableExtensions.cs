using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace GammaCore.Extensions
{
	public static class DataTableExtensions
	{
		/// <summary>
		/// Create the CSV content from the <see cref="DataTable"/>
		/// </summary>
		/// <param name="dataTable"></param>
		/// <param name="separator"></param>
		/// <returns></returns>
		public static string ToCsv(this DataTable dataTable, char separator = ';')
		{
			StringBuilder sb = new StringBuilder();

			IEnumerable<string> columnNames = dataTable.Columns.Cast<DataColumn>()
																.Select(column => column.ColumnName);

			sb.AppendLine(string.Join(";", columnNames));

			foreach (DataRow row in dataTable.Rows)
			{
				IEnumerable<string> fields = row.ItemArray.Select(field =>
				  string.Concat("\"", field.ToString().Replace("\"", "\"\"")
									.Replace(DateTime.MinValue.ToString(), ""), "\""));

				sb.AppendLine(string.Join(separator.ToString(), fields));
			}

			return sb.ToString();
		}
	}
}
