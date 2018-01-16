using System;
using System.Linq.Expressions;

namespace MustardBlack.Html.Forms.Configuration
{
	public interface IComponentIdResolver
	{
		string ResolveId<TEntity, TProperty>(Expression<Func<TEntity, TProperty>> property, string controlPrefix);
	}
}