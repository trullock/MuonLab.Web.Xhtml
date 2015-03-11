using System;
using System.Globalization;
using System.Linq.Expressions;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml
{
	public class DefaultTermResolver : ITermResolver
	{
		public virtual string ResolveLabel<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, CultureInfo culture)
		{
			var memberInfo = ReflectionHelper.GetMemberInfo(property);
			var term = memberInfo.GetTerm();
			return this.ResolveTerm(term, culture);
		}

		public virtual string ResolveTerm(object obj, CultureInfo culture)
		{
			return obj.ToString().ToEnglish(LanguageMode.CamelCase);
		}
	}
}