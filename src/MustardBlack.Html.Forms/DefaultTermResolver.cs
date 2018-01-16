using System;
using System.Globalization;
using System.Linq.Expressions;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
{
	public class DefaultTermResolver : ITermResolver
	{
		public virtual string ResolveTerm<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			var memberInfo = ReflectionHelper.GetMemberInfo(property);
			var term = memberInfo.GetTerm();
			return term;
		}

		public virtual string ResolveTerm(object obj, CultureInfo culture)
		{
			return obj.ToString().ToEnglish(LanguageMode.CamelCase);
		}
	}
}