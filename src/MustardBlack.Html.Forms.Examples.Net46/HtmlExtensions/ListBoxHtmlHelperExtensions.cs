using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class ListBoxHtmlHelperExtensions
	{
		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <typeparam name="TPropertyInner"></typeparam>
		/// <typeparam name="TData"></typeparam>
		/// <param name="html"></param>
		/// <param name="property"></param>
		/// <param name="items"></param>
		/// <param name="propValueFunc"></param>
		/// <param name="itemValueFunc"></param>
		/// <param name="itemTextFunc"></param>
		/// <param name="itemHtmlAttributes"></param>
		/// <returns></returns>
		public static IListBoxComponent<IEnumerable<TPropertyInner>> ListBoxFor<TViewModel, TPropertyInner, TData>(this HtmlHelper<TViewModel> html, 
			Expression<Func<TViewModel, IEnumerable<TPropertyInner>>> property, IEnumerable<TData> items, Func<TData, TPropertyInner> propValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes = null)
		{
			return html.ComponentFactory().ListBoxFor(property, html.ViewData.Model, items, propValueFunc, itemValueFunc,
				itemTextFunc, itemHtmlAttributes);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <typeparam name="TData"></typeparam>
		/// <param name="html"></param>
		/// <param name="property"></param>
		/// <param name="items"></param>
		/// <param name="propValueFunc"></param>
		/// <param name="itemValueFunc"></param>
		/// <param name="itemTextFunc"></param>
		/// <param name="itemHtmlAttributes"></param>
		/// <returns></returns>
		public static IListBoxComponent<IEnumerable<Guid>> ListBoxFor<TViewModel, TData>(this HtmlHelper<TViewModel> html, 
			Expression<Func<TViewModel, IEnumerable<Guid>>> property, IEnumerable<TData> items, Func<TData, Guid> propValueFunc, Func<TData, Guid> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes = null)
		{
			return html.ComponentFactory().ListBoxFor(property, html.ViewData.Model, items, propValueFunc, x => itemValueFunc(x).ToString(), itemTextFunc, itemHtmlAttributes);
		}
	}
}