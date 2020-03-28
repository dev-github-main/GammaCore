using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace GammaCore.Extensions
{
	public static class EnumerableExtensions
	{
		/// <summary>
		/// Create a datatable from a <see cref="IList{T}"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public static DataTable ToDataTable<T>(this IList<T> data)
		{
			DataTable result = new DataTable();

			PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(T));
			for (int i = 0; i < props.Count; i++)
			{
				PropertyDescriptor prop = props[i];
				result.Columns.Add(prop.Name, prop.PropertyType);
			}

			object[] values = new object[props.Count];

			foreach (T item in data)
			{
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = props[i].GetValue(item);
				}
				result.Rows.Add(values);
			}

			return result;
		}

		/// <summary>
		/// Create a datatable from a <see cref="IEnumerable{T}"/>
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="data"></param>
		/// <returns></returns>
		public static DataTable ToDataTable<T>(this IEnumerable<T> data)
		{
			return data.ToList().ToDataTable();
		}
	}
}
