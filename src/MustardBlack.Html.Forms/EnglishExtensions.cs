using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace MustardBlack.Html.Forms
{
	public static class EnglishExtensions
	{
		/// <summary>
		/// Attempts to de-camel case a string. For example: "HelloWorld" => "Hello world"
		/// </summary>
		/// <param name="self"></param>
		/// <param name="mode"></param>
		/// <returns>A de-camel-cased version of the string, starting with a capital</returns>
		public static string ToEnglish(this string self, LanguageMode mode = LanguageMode.SentenceCase)
		{
			//string s = Regex.Replace(self, "([A-Z0-9])", " $1").ToLower().Trim();
			//return s.Substring(0, 1).ToUpper() + s.Substring(1);

			var builder = new StringBuilder();
			for(int i = 0 ; i< self.Length; i++)
			{
				char lastChar = i > 0 ? self[i - 1] : default(char);
				char thisChar = self[i];
				char nextChar = i < self.Length - 1 ? self[i + 1] : default(char);

				// if the current char is an upper case
				if (thisChar.IsBreakingChar())
				{
					// if we are on the first char
					if(i == 0)
					{
						builder.Append(thisChar);
					}
					else
					{
						// if its an underscore
						if (thisChar == '_')
						{
							builder.Append(" -");
						}
						// if the last char was capital
						else if (lastChar.IsBreakingChar() && lastChar != '_')
						{
							// if the next char is captial
							if (nextChar.IsBreakingChar())
							{
								// middle of an series of capitals
								builder.Append(thisChar);
							}
							else if (nextChar == default(char))
							{
								// last of an series of capitals, at the end of the string
								builder.Append(thisChar);
							}
							else
							{
								// last char of series of capitals
								// new capital letter
								builder.Append(' ');
								// +32 to decapitalise
								builder.Append(thisChar.Decapitalise());
							}
						}
							// new capital letter
						else
						{
							builder.Append(' ');
							if (nextChar.IsBreakingChar())
							{
								builder.Append(thisChar);
							}
							else
							{
								builder.Append(mode == LanguageMode.SentenceCase ? thisChar.Decapitalise() : thisChar);
							}
						}
					}
				}
				else
				{
					builder.Append(thisChar);
				}
			}
			return builder.ToString();
		}

		public static string ToTerm(this Enum e)
		{
			var type = e.GetType();
			var memberInfos = type.GetMember(e.ToString());
			if (!memberInfos.Any())
				return null;

			var memberInfo = memberInfos.First();

			var customAttributes = memberInfo.GetCustomAttributes(typeof(TermAttribute), true);
			if (customAttributes.Length == 1)
				return (customAttributes[0] as TermAttribute).Key;

			return e.GetType().Name + '_' + e.ToString();
		}

		static bool IsBreakingChar(this char self)
		{
			return (self >= 65 && self <= 90) || (self >= 48 && self <= 57) || self == '_';
		}

		static char Decapitalise(this char self)
		{
			return (self >= 65 && self <= 90) ? (char)(self + 32) : self;
		}

		/// <summary>
		/// Returns Yes/No for true/false
		/// </summary>
		/// <param name="self"></param>
		/// <returns>Yes/No for true/false</returns>
		public static string ToEnglish(this bool self)
		{
			return self ? "Yes" : "No";
		}

		/// <summary>
		/// Gets an english version of a property's name, examining the EnglishName attribute if present
		/// </summary>
		/// <param name="info"></param>
		/// <param name="mode"></param>
		/// <returns></returns>
		public static string GetTerm(this MemberInfo info)
		{
			var attributes = info.GetCustomAttributes(false);
			var term = attributes.FirstOrDefault(a => a.GetType() == typeof(TermAttribute)) as TermAttribute;
			
            return term != null ? term.Key : info.Name;
		}

		/// <summary>
		/// Gets the english version of a type's name. For nullable types, the underlying type name is returned
		/// </summary>
		/// <param name="type"></param>
		/// <returns></returns>
		public static string GetEnglishName(this Type type)
		{
			Type propType;
			if ((type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>)))
			{
				var nc = new NullableConverter(type);
				propType = nc.UnderlyingType;
			}
			else
				propType = type;

			return propType.Name.ToLower();
		}

		
	}

	public enum LanguageMode
	{
		SentenceCase,
		CamelCase
	}
}