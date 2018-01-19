using System;
using System.Collections.Generic;
using System.Linq;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	internal static class EnumHelper
	{
		public static IEnumerable<TEnum> GetEnumValues<TEnum>(bool excludeCombinations = false)
		{
			IEnumerable<TEnum> values;

			var enumType = typeof(TEnum);

			if (enumType.IsEnum)
				values = Enumerator.GetAll<TEnum>();
			else if (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
				values = Enumerator.GetAll(enumType.GetGenericArguments()[0]).Cast<TEnum>();
			else
				throw new ArgumentException("TProperty: `" + enumType + "` must be an Enum");

			if (!excludeCombinations)
				return values;

			return values.Where(v => !(v as Enum).IsFlagCombination());
		}

		static bool IsSignedTypeCode(TypeCode code)
		{
			switch (code)
			{
				case TypeCode.Byte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return false;
				default:
					return true;
			}
		}

		public static bool IsFlagSet(this Enum value, Enum option)
		{
			if (IsSignedTypeCode(value.GetTypeCode()))
			{
				var longVal = Convert.ToInt64(value);
				var longOpt = Convert.ToInt64(option);
				return (longVal & longOpt) == longOpt;
			}
			else
			{
				var longVal = Convert.ToUInt64(value);
				var longOpt = Convert.ToUInt64(option);
				return (longVal & longOpt) == longOpt;
			}
		}

		static bool IsFlagCombination(this Enum value)
		{
			if (IsSignedTypeCode(value.GetTypeCode()))
			{
				var longVal = Convert.ToInt64(value);
				return longVal == 0 || (longVal & (longVal - 1)) != 0;
			}
			else
			{
				var longVal = Convert.ToUInt64(value);
				return longVal == 0 || (longVal & (longVal - 1)) != 0;
			}
		}
	}
}