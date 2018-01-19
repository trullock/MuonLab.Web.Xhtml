using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class RadioButtonListHtmlHelperExtensions
	{
		public static IRadioButtonListComponent RadioButtonListFor<TViewModel>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, bool>> property)
		{
			var componentFactory = html.ComponentFactory();
			var termResolver = componentFactory.TermResolver;
			return componentFactory.RadioButtonListFor(property, html.ViewData.Model, new[] { true, false }, b => termResolver.ResolveTerm(b, componentFactory.Culture), b => b.ToString().ToUpperInvariant());
		}

		public static IRadioButtonListComponent RadioButtonListFor<TViewModel>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, bool?>> property)
		{
			var componentFactory = html.ComponentFactory();
			var termResolver = componentFactory.TermResolver;
			return componentFactory.RadioButtonListFor(property, html.ViewData.Model, new[] { true, false }, b => termResolver.ResolveTerm(b, componentFactory.Culture), b => b.ToString().ToUpperInvariant());
		}

		public static IRadioButtonListComponent RadioButtonListFor<TViewModel, TProperty, TData>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property, IEnumerable<TData> items, Func<TData, string> valueFunc, Func<TData, string> textFunc)
		{
			return html.ComponentFactory().RadioButtonListFor(property, html.ViewData.Model, items, valueFunc, textFunc);
		}
	}
}