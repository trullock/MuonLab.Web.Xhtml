using System;
using System.Globalization;
using System.Linq.Expressions;

namespace MuonLab.Web.Xhtml.Configuration
{
	public interface ITermResolver
	{
		string ResolveLabel<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, CultureInfo culture);
		string ResolveTerm(object obj, CultureInfo culture);
	}
}