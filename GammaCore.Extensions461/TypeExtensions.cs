﻿using System;

namespace GammaCore.Extensions
{
	public static class TypeExtensions
	{
		/// <summary>
		/// Determines whether given type is assignable to generic type.
		/// </summary>
		/// <param name="givenType">A given type.</param>
		/// <param name="genericType">A generic type.</param>
		/// <returns>
		///   <c>true</c> if given type is assignable to generic type; otherwise, <c>false</c>.
		/// </returns>
		public static bool IsAssignableToGenericType(this Type givenType, Type genericType)
		{
			if (givenType == genericType) { return true; }

			Type[] interfaceTypes = givenType.GetInterfaces();
			foreach (Type it in interfaceTypes)
			{
				if (it == genericType) { return true; }

				if (it.IsGenericType && it.GetGenericTypeDefinition() == genericType)
				{
					return true;
				}
			}

			Type baseType = givenType.BaseType;
			if (baseType == null)
			{
				return false;
			}

			return (baseType.IsGenericType && baseType.GetGenericTypeDefinition() == genericType) || IsAssignableToGenericType(baseType, genericType);
		}
	}
}
