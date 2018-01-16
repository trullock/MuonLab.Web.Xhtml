using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Configuration
{
	public interface IComponentNameResolver
	{
		string ResolveName<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property);
	}
}