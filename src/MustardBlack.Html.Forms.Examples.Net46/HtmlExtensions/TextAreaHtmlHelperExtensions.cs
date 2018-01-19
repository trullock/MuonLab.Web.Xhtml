using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class TextAreaHtmlHelperExtensions
	{
		public static ITextAreaComponent TextAreaFor<TViewData>(this HtmlHelper<TViewData> html, Expression<Func<TViewData, string>> property)
		{
			return html.ComponentFactory().TextAreaFor(property, html.ViewData.Model);
		}

		public static ITextAreaComponent TextAreaFor<TViewData>(this HtmlHelper<TViewData> html, Expression<Func<TViewData, IEnumerable<string>>> property)
		{
			return html.ComponentFactory().TextAreaFor(property, html.ViewData.Model);
		}

		public static ITextAreaComponent TextAreaFor<TViewData>(this HtmlHelper<TViewData> html, Expression<Func<TViewData, IEnumerable<IEnumerable<string>>>> property)
		{
			return html.ComponentFactory().TextAreaFor(property, html.ViewData.Model);
		}
	}
}