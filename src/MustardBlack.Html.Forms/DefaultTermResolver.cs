using System;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
{
	public class DefaultTermResolver : ITermResolver
	{
		public virtual string ResolveTerm<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			var expressionText = ExpressionHelper.GetExpressionText(property);

			var term = expressionText.Split('.').Last();
			var indexOf = term.IndexOf('[');
			if (indexOf > -1)
				term = term.Substring(0, indexOf);

			return term;
		}

		public virtual string ResolveTerm(object obj, CultureInfo culture)
		{
			return obj.ToString().ToEnglish(LanguageMode.CamelCase);
		}
	}
}