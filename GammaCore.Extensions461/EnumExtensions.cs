using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Resources;

namespace GammaCore.Extensions
{
	public static class EnumExtensions
	{
		/// <summary>
		/// Get the string from a <see cref="Enum"/> property. If the <see cref="Enum"/> properties has the 
		/// <see cref="DisplayAttribute"/> returns the value of the attribute.
		/// </summary>
		/// <param name="enum"></param>
		/// <returns>The <see cref="string"/> value of the <see cref="Enum"/> property</returns>
		public static string GetDisplayValue(this Enum @enum)
		{
			return GetDisplayValueFromObject(@enum);
		}

		/// <summary>
		/// Get the string from all the <see cref="Enum"/> properties. If the <see cref="Enum"/> properties has the 
		/// <see cref="DisplayAttribute"/> or the <see cref="DescriptionAttribute"/> returns the value of the attribute.
		/// </summary>
		/// <param name="enum"></param>
		/// <returns>The <see cref="List[string]"/> of all values of the <see cref="Enum"/> properties</returns>
		/// <exception cref="NotSupportedException"></exception>
		public static IEnumerable<KeyValuePair<int, string>> ToDictionary(this Type @enum)
		{
			List<KeyValuePair<int, string>> result = new List<KeyValuePair<int, string>>();
			if (@enum.IsEnum)
			{
				foreach (var item in Enum.GetValues(@enum))
				{
					result.Add(new KeyValuePair<int, string>((int)item, ((Enum)item).GetDisplayValue()));
				}
			}
			else
			{
				throw new NotSupportedException(string.Format("The type {0} is not supported", @enum.ToString()));
			}

			return result;
		}

		#region HELPERS

		private static string GetDisplayValueFromObject(object value)
		{
			MemberInfo[] fieldInfo = value.GetType().GetMember(value.ToString());


			if (fieldInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false) is DisplayAttribute[] displayAttributes
					&& displayAttributes.Length > 0)
			{
				if (displayAttributes[0].ResourceType != null && !string.IsNullOrEmpty(displayAttributes[0].Name))
				{
					return LookupResource(displayAttributes[0].ResourceType, displayAttributes[0].Name);
				}
				else if (!string.IsNullOrEmpty(displayAttributes[0].Name))
				{
					return displayAttributes[0].Name;
				}
			}

			DescriptionAttribute[] descriptionAttributes = fieldInfo[0].GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
			if (descriptionAttributes != null && descriptionAttributes.Length > 0 && !string.IsNullOrEmpty(descriptionAttributes[0].Description))
			{
				return descriptionAttributes[0].Description;
			}

			return value.ToString();
		}

		private static string LookupResource(Type resourceManagerProvider, string resourceKey)
		{
			foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
			{
				if (staticProperty.PropertyType == typeof(ResourceManager))
				{
					ResourceManager resourceManager = (ResourceManager)staticProperty.GetValue(null, null);
					return resourceManager.GetString(resourceKey);
				}
			}

			return resourceKey;
		}

		#endregion
	}
}
