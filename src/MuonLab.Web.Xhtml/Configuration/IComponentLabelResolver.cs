using System;
using System.Globalization;
using System.Linq.Expressions;

namespace MuonLab.Web.Xhtml.Configuration
{
	public interface ITermResolver
	{
		string ResolveTerm(object obj, CultureInfo culture);
		string ResolveTerm<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property);
	}
}