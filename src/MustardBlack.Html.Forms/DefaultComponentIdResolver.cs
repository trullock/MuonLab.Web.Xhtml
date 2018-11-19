using System;
using System.Linq.Expressions;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
{
	public class DefaultComponentIdResolver : IComponentIdResolver
	{
		readonly string prefix;

		public DefaultComponentIdResolver(string prefix)
		{
			this.prefix = prefix;
		}

		public string ResolveId<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, string controlPrefix)
		{
			return this.prefix + controlPrefix + ExpressionHelper.GetExpressionText(property).Replace(".", string.Empty);
		}

	}
}