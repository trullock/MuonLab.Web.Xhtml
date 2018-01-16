using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MustardBlack.Html.Forms
{
	public static class Enumerator
	{
		public static IEnumerable<TEnum> GetAll<TEnum>()
		{
			if(!typeof(TEnum).IsEnum)
				throw new ArgumentException("`" + typeof(TEnum) + "` is not an Enum");

			var values = Enum.GetNames(typeof (TEnum)).OrderBy(x => x).Select(n => (TEnum) Enum.Parse(typeof (TEnum), n)).ToArray();
			return values;
		}

		public static IEnumerable GetAll(Type enumType)
		{
			if (!enumType.IsEnum)
				throw new ArgumentException("`" + enumType + "` is not an Enum", "enumType");

			var values = Enum.GetNames(enumType).OrderBy(x => x).Select(n => Enum.Parse(enumType, n)).ToArray();
			return values;
		}
	}
}