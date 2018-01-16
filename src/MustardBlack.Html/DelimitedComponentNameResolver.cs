using System;
using System.Linq.Expressions;
using MustardBlack.Html.Configuration;

namespace MustardBlack.Html
{
	public class DelimitedComponentNameResolver : IComponentNameResolver
	{
		readonly char delimeter;

		public DelimitedComponentNameResolver(char delimeter = '.')
		{
			this.delimeter = delimeter;
		}

		public string ResolveName<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			return ReflectionHelper.PropertyChainToString(property, delimeter);
		}
	}
}