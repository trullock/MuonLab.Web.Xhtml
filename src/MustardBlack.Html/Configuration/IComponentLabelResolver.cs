using System;
using System.Globalization;
using System.Linq.Expressions;

namespace MustardBlack.Html.Configuration
{
	public interface ITermResolver
	{
		string ResolveTerm(object obj, CultureInfo culture);
		string ResolveTerm<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property);
	}
}