using System;
using System.Linq.Expressions;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
{
	public class DefaultComponentNameResolver : IComponentNameResolver
	{
		public string ResolveName<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property)
		{
			return ExpressionHelper.GetExpressionText(property);
		}
	}
}