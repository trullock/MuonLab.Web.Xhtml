using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web;
using System.Web.Mvc;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Example
{
	public static class HtmlHelperExtensions
	{
		static IComponentFactory<T> ComponentFactory<T>(this HtmlHelper<T> html)
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

		public static string NameOf<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property)
		{
			return html.ComponentFactory().NameResolver.ResolveName(property);
		}

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
			return html.ComponentFactory().DropDownFor(property, html.ViewData.Model, items, g => g.ToString(), v => itemValueFunc(v).ToString(), itemTextFunc, null);
		}


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
		/// <param name="itemHtmlAttributes"></param>
		/// <returns></returns>
		public static IDropDownComponent<Guid> DropDownFor<TViewModel, TData>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, Guid>> property, IEnumerable<TData> items, Func<TData, Guid> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes)
		{
			return html.ComponentFactory().DropDownFor(property, html.ViewData.Model, items, g => g.ToString(), v => itemValueFunc(v).ToString(), itemTextFunc, itemHtmlAttributes);
		}

		public static IDropDownComponent<TProperty> DropDownFor<TViewModel, TData, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property, IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc)
		{
			return html.ComponentFactory().DropDownFor(property, html.ViewData.Model, items, propertyValueFunc, itemValueFunc, itemTextFunc, null);
		}

		public static IDropDownComponent<TProperty> DropDownFor<TViewModel, TData, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property, IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes)
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
		/// <returns></returns>
		public static IDropDownComponent<TProperty> DropDownFor<TViewModel, TProperty>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, TProperty>> property)
		{
			var values = GetEnumValues<TProperty>();
			var componentFactory = html.ComponentFactory();		
			return componentFactory.DropDownFor(property, html.ViewData.Model, values, x => x.ToString(), x => x.ToString(), x => componentFactory.TermResolver.ResolveTerm(x, componentFactory.Culture), null);
		}

		static IEnumerable<TEnum> GetEnumValues<TEnum>()
		{
			return GetEnumValues<TEnum>(false);
		}

		static bool IsSignedTypeCode(TypeCode code)
		{
			switch (code)
			{
				case TypeCode.Byte:
				case TypeCode.UInt16:
				case TypeCode.UInt32:
				case TypeCode.UInt64:
					return false;
				default:
					return true;
			}
		}

		static bool IsFlagSet(this Enum value, Enum option)
		{
			if (IsSignedTypeCode(value.GetTypeCode()))
			{
				var longVal = Convert.ToInt64(value);
				var longOpt = Convert.ToInt64(option);
				return (longVal & longOpt) == longOpt;
			}
			else
			{
				var longVal = Convert.ToUInt64(value);
				var longOpt = Convert.ToUInt64(option);
				return (longVal & longOpt) == longOpt;
			}
		}

		static bool IsFlagCombination(this Enum value)
		{
			if (IsSignedTypeCode(value.GetTypeCode()))
			{
				var longVal = Convert.ToInt64(value);
				return longVal == 0 || (longVal & (longVal - 1)) != 0;
			}
			else
			{
				var longVal = Convert.ToUInt64(value);
				return longVal == 0 || (longVal & (longVal - 1)) != 0;
			}
		}

		static IEnumerable<TEnum> GetEnumValues<TEnum>(bool excludeCombinations)
		{
			IEnumerable<TEnum> values;

			var enumType = typeof(TEnum);

			if (enumType.IsEnum)
				values = Enumerator.GetAll<TEnum>();
			else if (enumType.IsGenericType && enumType.GetGenericTypeDefinition() == typeof(Nullable<>))
				values = Enumerator.GetAll(enumType.GetGenericArguments()[0]).Cast<TEnum>();
			else
				throw new ArgumentException("TProperty: `" + enumType + "` must be an Enum");

			if (!excludeCombinations)
				return values;

			return values.Where(v => !(v as Enum).IsFlagCombination());
		}

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
				throw new ArgumentException("`" + typeof(TEnum) + "` is not an Enum", "property");
			
			var values = GetEnumValues<TEnum>(true);
			var componentFactory = html.ComponentFactory();
			var termResolver = componentFactory.TermResolver;

			return componentFactory.CheckBoxListFor(property, html.ViewData.Model, values, v => v.ToString(), v => termResolver.ResolveTerm(v, componentFactory.Culture), (x, y) => (x as Enum).IsFlagSet(y as Enum));
		}


		public static IFileUploadComponent FileUploadFor<TViewModel>(this HtmlHelper<TViewModel> html, Expression<Func<TViewModel, HttpPostedFileBase>> property)
		{
			return html.ComponentFactory().FileUploadFor(property, html.ViewData.Model);
		}

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