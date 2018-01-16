using System;
using System.Linq.Expressions;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
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