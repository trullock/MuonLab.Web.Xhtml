using System;
using System.Collections.Generic;
using System.Globalization;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
	public class DropDownComponent<TViewModel, TProperty, TData> :
		VisibleComponent<TViewModel, TProperty>,
		IDropDownComponent<TProperty>
	{
		readonly IEnumerable<TData> items;
		
		readonly Func<TProperty, string> propValueFunc;
		readonly Func<TData, TProperty> itemValueFunc;
		readonly Func<TData, string> itemTextFunc;
		readonly Func<TData, object> itemHtmlAttributes;

		protected bool showNullOption;
		protected string nullOptionText;
		protected TProperty nullOptionValue;
		protected bool nullOptionValueSet;

		public DropDownComponent(ITermResolver termResolver, IValidationMessageRenderer validationMessageRenderer, CultureInfo culture, IEnumerable<TData> items,
			Func<TProperty, string> propValueFunc, Func<TData, TProperty> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes)
			: base(termResolver, validationMessageRenderer, culture)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items), "DropDown's data items enumerable cannot be null");

			this.items = items;
			this.propValueFunc = propValueFunc;
			this.itemValueFunc = itemValueFunc;
			this.itemTextFunc = itemTextFunc;
			this.itemHtmlAttributes = itemHtmlAttributes;
		}

		public override string ControlPrefix => "ddl";

		/// <summary>
		/// Adds a Null option with the default null option text.
		/// </summary>
		/// <returns></returns>
		public virtual IDropDownComponent WithNullOption()
		{
			return this.WithNullOption(this.termResolver.ResolveTerm("Choose", this.culture));
		}

		/// <summary>
		/// Adds a Null option with and sets the null option text.
		/// </summary>
		/// <param name="nullOptionText">The null option text.</param>
		/// <returns></returns>
		public virtual IDropDownComponent WithNullOption(string nullOptionText)
		{
			this.showNullOption = true;
			this.nullOptionText = nullOptionText;
			return this;
		}

		/// <summary>
		/// Adds a Null option with and sets the null option text.
		/// </summary>
		/// <param name="nullOptionText">The null option text.</param>
		/// <returns></returns>
		public virtual IDropDownComponent WithNullOption(string nullOptionText, TProperty nullOptionValue)
		{
			this.showNullOption = true;
			this.nullOptionText = nullOptionText;
			this.nullOptionValue = nullOptionValue;
			this.nullOptionValueSet = true;
			return this;
		}

		/// <summary>
		/// Removes a previously set null option
		/// </summary>
		/// <returns></returns>
		public virtual IDropDownComponent WithoutNullOption()
		{
			this.showNullOption = false;
			this.nullOptionValueSet = false;
			return this;
		}

		protected override string RenderComponent()
		{
			if (this.ariaLabel)
				this.htmlAttributes["aria-label"] = this.termResolver.ResolveTerm(this.Label, this.culture);
			
			var builder = new TagBuilder("select", this.htmlAttributes);

			this.AddAriaDescribedBy();

			if (this.showNullOption)
			{
				var nullValue = this.nullOptionValueSet ? propValueFunc(this.nullOptionValue) : string.Empty;
				var nullOptionBuilder = new TagBuilder("option", new Dictionary<string, object>
				{
					{"value", nullValue},
					{"data-null-value", "true"}
				});
				nullOptionBuilder.SetInnerText(this.nullOptionText);
				builder.InnerHtml = nullOptionBuilder.ToString();
			}

			foreach (var item in items)
			{
				var optionAttributes = itemHtmlAttributes?.Invoke(item);

				var optionBuilder = new TagBuilder("option", optionAttributes);

				optionBuilder.HtmlAttributes.Add("value", this.itemValueFunc.Invoke(item));

				if (!ReferenceEquals(this.value, null) && Equals(this.value, this.itemValueFunc.Invoke(item)))
					optionBuilder.HtmlAttributes.Add("selected", new HtmlProperty());

				optionBuilder.SetInnerText(this.itemTextFunc.Invoke(item));

				builder.InnerHtml += optionBuilder.ToString();
			}

			return builder.ToString();
		}
	}
}