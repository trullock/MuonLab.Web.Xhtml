using System;
using System.Globalization;
using System.Web;
using System.Web.Mvc;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public static class FormHtmlHelperExtensions
	{
		public static IComponentFactory<T> ComponentFactory<T>(this HtmlHelper<T> html)
		{
			return html.ViewContext.HttpContext.Items["__ComponentFactory"] as IComponentFactory<T>;
		}

		static void DisposeComponentFactory<T>(this HtmlHelper<T> html)
		{
			html.ViewContext.HttpContext.Items["__ComponentFactory"] = null;
		}

		static void EnsureComponentFactoryExists<T, TFormConfiguration>(this HtmlHelper<T> html) where TFormConfiguration : IFormConfiguration, new()
		{
			if (html.ComponentFactory() == null)
				html.ViewContext.HttpContext.Items["__ComponentFactory"] = html.CreateComponentFactory<T, TFormConfiguration>();
		}

		/// <summary>
		/// Begins a new form for use with the ComponentFactory
		/// </summary>
		/// <returns></returns>
		public static IHtmlString BeginForm<T>(this HtmlHelper<T> html)
		{
			return html.BeginForm<ExampleFormConfiguration, T>(null);
		}

		/// <summary>
		/// Begins a new form for use with the ComponentFactory
		/// </summary>
		/// <returns></returns>
		public static IHtmlString BeginForm<T>(this HtmlHelper<T> html, object attributes)
		{
			return html.BeginForm<ExampleFormConfiguration, T>(attributes);
		}

		/// <summary>
		/// Begins a new form for use with the ComponentFactory, specifying the type of the form configuration to use
		/// </summary>
		/// <returns></returns>
		public static IHtmlString BeginForm<TFormConfiguration, T>(this HtmlHelper<T> html) where TFormConfiguration : IFormConfiguration, new()
		{
			return html.BeginForm<TFormConfiguration, T>(null);
		}

		/// <summary>
		/// Begins a new form for use with the ComponentFactory, specifying the type of the form configuration to use
		/// </summary>
		/// <returns></returns>
		public static IHtmlString BeginForm<TFormConfiguration, T>(this HtmlHelper<T> html, object attributes) where TFormConfiguration : IFormConfiguration, new()
		{
			if (html.ComponentFactory() != null)
				throw new InvalidOperationException("ComponentFactory is already inititalized. Have you called Html.EndForm()? Are you nesting forms?");

			html.EnsureComponentFactoryExists<T, TFormConfiguration>();

			var formBuilder = new TagBuilder("form", attributes);

			if (!formBuilder.HtmlAttributes.ContainsKey("method"))
				formBuilder.HtmlAttributes.Add("method", "post");

			if (!formBuilder.HtmlAttributes.ContainsKey("action"))
				formBuilder.HtmlAttributes.Add("action", "#");

			return new HtmlString(formBuilder.ToString(TagRenderMode.StartTag));
		}

		public static IHtmlString EndForm<T>(this HtmlHelper<T> html)
		{
			html.DisposeComponentFactory();
			return new HtmlString("</form>");
		}

		static IComponentFactory<TViewData> CreateComponentFactory<TViewData, TFormConfiguration>(this HtmlHelper<TViewData> html) where TFormConfiguration : IFormConfiguration, new()
		{
			// get the specified form config
			var formConfiguration = new TFormConfiguration();

			// standard bits
			var componentLabelResolver = new ResourceTermResolver();
			var componentNameResolver = new DelimitedComponentNameResolver();
			var componentIdResolver = new DefaultComponentIdResolver();


			var errorProvider = new MvcErrorProvider(html.ViewData.ModelState);
			return new ComponentFactory<TViewData>(formConfiguration, componentNameResolver, componentIdResolver, componentLabelResolver, errorProvider, CultureInfo.CurrentCulture);
		}
	}
}