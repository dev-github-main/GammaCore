using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace GammaCore.Extensions
{
	public static class AssemblyExtensions
	{
		/// <summary>
		/// Get the attributes of a given attribute type
		/// </summary>
		/// <typeparam name="T">The attribute type</typeparam>
		/// <param name="assembly">The assembly</param>
		/// <returns>Return <see cref="IEnumerable{T}"/></returns>
		public static IEnumerable<T> GetAttributes<T>(this Assembly assembly) where T : Attribute
		{
			try
			{
				return assembly.GetCustomAttributes(typeof(T), inherit: false).OfType<T>();
			}
			catch
			{
				return Enumerable.Empty<T>();
			}
		}
	}
}
