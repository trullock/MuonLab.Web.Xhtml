using System;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class InputHtmlHelperExtensions
	{
		public static IHiddenFieldComponent<TProperty> HiddenFieldFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property)
		{
			return html.ComponentFactory().HiddenFieldFor(property, html.ViewData.Model, x => x.ToString());
		}

		public static ITextBoxComponent<TProperty> TextBoxFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property)
		{
			return html.ComponentFactory().TextBoxFor(property, html.ViewData.Model);
		}

		public static IPasswordBoxComponent PasswordBoxFor<TViewModel>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, string>> property)
		{
			return html.ComponentFactory().PasswordBoxFor(property, html.ViewData.Model);
		}
		
		public static IFileUploadComponent FileUploadFor<TViewModel>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, HttpPostedFileBase>> property)
		{
			return html.ComponentFactory().FileUploadFor(property, html.ViewData.Model);
		}
	}
}