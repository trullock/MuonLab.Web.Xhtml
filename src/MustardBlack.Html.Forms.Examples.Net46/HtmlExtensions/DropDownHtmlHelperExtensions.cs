using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class DropDownHtmlHelperExtensions
	{
		/// <summary>
		/// Creates a DropDown list for a Guid property
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <typeparam name="TData"></typeparam>
		/// <param name="html"></param>
		/// <param name="property">The property value</param>
		/// <param name="items">Available items</param>
		/// <param name="itemValueFunc">Func to get a Guid value from each item</param>
		/// <param name="itemTextFunc">Func to get the text to display from each item</param>
		/// <returns></returns>
		public static IDropDownComponent<Guid> DropDownFor<TViewModel, TData>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, Guid>> property, IEnumerable<TData> items, Func<TData, Guid> itemValueFunc, Func<TData, string> itemTextFunc)
		{
			return html.ComponentFactory().DropDownFor(property, html.ViewData.Model, items, g => g.ToString(), itemValueFunc, itemTextFunc, null);
		}
		
		/// <summary>
		/// Creates a DropDown list for a property
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <typeparam name="TProperty"></typeparam>
		/// <typeparam name="TData"></typeparam>
		/// <param name="html"></param>
		/// <param name="property"></param>
		/// <param name="items"></param>
		/// <param name="propertyValueFunc">How to turn the property type into a string</param>
		/// <param name="itemValueFunc">How to get the property type from the data type</param>
		/// <param name="itemTextFunc">How to get the property text from the data type</param>
		/// <param name="itemHtmlAttributes"></param>
		/// <returns></returns>
		public static IDropDownComponent<TProperty> DropDownFor<TViewModel, TProperty, TData>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property, IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, TProperty> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes = null)
		{
			return html.ComponentFactory().DropDownFor(property, html.ViewData.Model, items, propertyValueFunc, itemValueFunc, itemTextFunc, itemHtmlAttributes);
		}

		/// <summary>
		/// Creates a DropDown List for an Enum property
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <typeparam name="TProperty"></typeparam>
		/// <param name="html"></param>
		/// <param name="property"></param>
		/// <param name="itemHtmlAttributes"></param>
		/// <returns></returns>
		public static IDropDownComponent<TProperty> DropDownFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property, Func<TProperty, object> itemHtmlAttributes = null)
		{
			var values = EnumHelper.GetEnumValues<TProperty>();
			var componentFactory = html.ComponentFactory();		
			return componentFactory.DropDownFor(property, html.ViewData.Model, values, x => x.ToString(), x => x, x => componentFactory.TermResolver.ResolveTerm(x, componentFactory.Culture), itemHtmlAttributes);
		}
	}
}