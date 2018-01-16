using System;
using System.Linq.Expressions;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
{
	public class DefaultComponentIdResolver : IComponentIdResolver
	{
		public string ResolveId<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, string controlPrefix)
		{
			// TODO: De-meh this
			return controlPrefix + ReflectionHelper.PropertyChainToString(property, '!').Replace("!", string.Empty);
		}
	}
}