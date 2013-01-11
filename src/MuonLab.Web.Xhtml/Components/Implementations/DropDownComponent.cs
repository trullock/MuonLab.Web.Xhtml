using System;
using System.Collections.Generic;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
	public class DropDownComponent<TViewModel, TProperty, TData> :
		VisibleComponent<TViewModel, TProperty>,
		IDropDownComponent<TProperty>
	{
		readonly IEnumerable<TData> items;
		readonly Func<TProperty, string> propertyValueFunc;
		readonly Func<TData, string> itemValueFunc;
		readonly Func<TData, string> itemTextFunc;
		protected bool showNullOption;
		protected string nullOptionText;
		protected TProperty nullOptionValue;
		protected bool nullOptionValueSet;

		public DropDownComponent(IEnumerable<TData> items, Func<TProperty, string> propertyValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc)
		{
			if (items == null)
				throw new ArgumentNullException("items", "DropDown's data items enumerable cannot be null");

			this.items = items;
			this.propertyValueFunc = propertyValueFunc;
			this.itemValueFunc = itemValueFunc;
			this.itemTextFunc = itemTextFunc;
		}

		public override string ControlPrefix
		{
			get { return "ddl"; }
		}

		/// <summary>
		/// Adds a Null option with the default null option text.
		/// </summary>
		/// <returns></returns>
		public virtual IDropDownComponent WithNullOption()
		{
			return this.WithNullOption("--Choose--");
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
			var builder = new TagBuilder("select", this.htmlAttributes);

			if (this.showNullOption)
			{
				var nullValue = this.nullOptionValueSet ? propertyValueFunc(this.nullOptionValue) : string.Empty;
				var nullOptionBuilder = new TagBuilder("option", new Dictionary<string, object> {{"value", nullValue}});
				nullOptionBuilder.SetInnerText(this.nullOptionText);
				builder.InnerHtml = nullOptionBuilder.ToString();
			}

			foreach (var item in items)
			{
				var optionAttributes = new Dictionary<string, object>
					                       {
						                       {"value", this.itemValueFunc.Invoke(item)}
					                       };

				if (!ReferenceEquals(this.value, null) && Equals(propertyValueFunc(this.value), itemValueFunc(item)))
					optionAttributes.Add("selected", "selected");

				var optionBuilder = new TagBuilder("option", optionAttributes);
				optionBuilder.SetInnerText(this.itemTextFunc.Invoke(item));

				builder.InnerHtml += optionBuilder.ToString();
			}

			return builder.ToString();
		}
	}
}