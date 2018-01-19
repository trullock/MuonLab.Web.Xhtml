using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class CheckBoxHtmlHelperExtensions
	{
		public static ICheckBoxComponent<bool> CheckBoxFor<TViewData>(this HtmlHelper<TViewData> html, Expression<Func<TViewData, bool>> property)
		{
			return html.ComponentFactory().CheckBoxFor(property, html.ViewData.Model);
		}

		public static ICheckBoxComponent<IEnumerable<TInner>> CheckBoxFor<TViewData, TInner>(this HtmlHelper<TViewData> html, Expression<Func<TViewData, IEnumerable<TInner>>> property, TInner value)
		{
			return html.ComponentFactory().CheckBoxFor(property, html.ViewData.Model, value);
		}

		public static ICheckBoxListComponent CheckBoxListFor<TViewModel>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, string>> property, IEnumerable<string> items)
		{
			return html.ComponentFactory().CheckBoxListFor(property, html.ViewData.Model, items, x => x, x => x, (vs, i) =>
			{
				if (vs == null)
					throw new ComponentRenderingException("Cannot render CheckBoxList for IEnumerable property `" + property.ToString() + "`, the property is null. It must have a value.");
				return vs.Contains(i);
			});
		}

		public static ICheckBoxListComponent CheckBoxListFor<TViewModel, TInnerProp, TData>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, IEnumerable<TInnerProp>>> property, IEnumerable<TData> items, Func<TData, TInnerProp> valueFunc, Func<TData, string> textFunc)
		{
			return html.ComponentFactory().CheckBoxListFor(property, html.ViewData.Model, items, x => valueFunc(x).ToString(), textFunc, (vs, i) =>
			{
				if (vs == null)
					throw new ComponentRenderingException("Cannot render CheckBoxList for IEnumerable property `" + property.ToString() + "`, the property is null. It must have a value.");
				return vs.Contains(valueFunc(i));
			});
		}

		public static ICheckBoxListComponent CheckBoxListFor<TViewModel, TEnum>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TEnum>> property)
		{
			if (!typeof(TEnum).IsEnum)
				throw new ArgumentException("`" + typeof(TEnum) + "` is not an Enum", nameof(property));
			
			var values = EnumHelper.GetEnumValues<TEnum>(true);
			var componentFactory = html.ComponentFactory();
			var termResolver = componentFactory.TermResolver;

			return componentFactory.CheckBoxListFor(property, html.ViewData.Model, values, v => v.ToString(), v => termResolver.ResolveTerm(v, componentFactory.Culture), (x, y) => (x as Enum).IsFlagSet(y as Enum));
		}
	}
}