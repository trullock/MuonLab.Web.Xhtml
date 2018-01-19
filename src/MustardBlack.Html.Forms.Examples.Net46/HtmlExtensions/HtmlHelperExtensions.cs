using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class HtmlHelperExtensions
	{
		public static string NameOf<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property)
		{
			return html.ComponentFactory().NameResolver.ResolveName(property);
		}
	}
}