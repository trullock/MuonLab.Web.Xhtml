using System;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class ValidationHtmlHelperExtensions
	{
		public static string ValidationMessageFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property)
		{
			return html.ComponentFactory().ValidationMessageFor(property, html.ViewData.Model);
		}

		/// <summary>
		/// Creates a Validation Summary with Anchors
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="html"></param>
		/// <returns></returns>
		public static IHtmlString ValidationSummary<TViewModel>(this HtmlHelper<TViewModel> html)
		{
			return html.ValidationSummary(ValidationSummaryMode.ListWithAnchors);
		}

		/// <summary>
		/// Creates a Validation Summary
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="html"></param>
		/// <param name="mode">The error display mode</param>
		/// <returns></returns>
		public static IHtmlString ValidationSummary<TViewModel>(this HtmlHelper<TViewModel> html, ValidationSummaryMode mode)
		{
			return html.ValidationSummary("There were the following problems with the data you entered:", mode);
		}

		/// <summary>
		/// Creates a Validation Summary
		/// </summary>
		/// <typeparam name="TViewModel"></typeparam>
		/// <param name="html"></param>
		/// <param name="headerText">The header message to display introducing the errors</param>
		/// <param name="mode">The error display mode</param>
		/// <returns></returns>
		public static IHtmlString ValidationSummary<TViewModel>(this HtmlHelper<TViewModel> html, string headerText, ValidationSummaryMode mode)
		{
			if (!html.ViewData.ModelState.IsValid)
			{
				var builder = new StringBuilder("<div class=\"validation-summary\">");

				var pTag = new TagBuilder("p", new { @class = "validation-summary-message" });
				pTag.InnerHtml = html.Encode(headerText);

				builder.Append(pTag.ToString());

				if (mode != ValidationSummaryMode.HeaderOnly)
				{
					builder.Append("<ul class=\"validation-summary-errors\">");

					foreach (var key in html.ComponentFactory().ErrorProvider.AllErrors.Keys)
						foreach (var error in html.ComponentFactory().ErrorProvider.AllErrors[key])
						{
							if (key == string.Empty || mode == ValidationSummaryMode.List)
								builder.Append("<li>" + error + "</li>");
							else
								builder.Append("<li><a href=\"#" + key + "\" title=\"Click to jump to erroneous field\">" + error + "</a></li>");
						}

					builder.Append("</ul>");

				}

				builder.Append("</div>");

				return new HtmlString(builder.ToString());
			}

			return null;
		}
	}
}