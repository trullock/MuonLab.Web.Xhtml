using System;
using System.Collections.Generic;
using System.Globalization;
using MustardBlack.Html.Forms.Configuration;
using System.Linq;

namespace MustardBlack.Html.Forms.Components
{
	public class ListBoxComponent<TViewModel, TPropertyInner, TData> :
		VisibleComponent<TViewModel, IEnumerable<TPropertyInner>>,
		IListBoxComponent<IEnumerable<TPropertyInner>>
	{
		readonly IEnumerable<TData> items;
		readonly Func<TData, TPropertyInner> propValueFunc;
		readonly Func<TData, string> itemValueFunc;
		readonly Func<TData, string> itemTextFunc;
		readonly Func<TData, object> itemHtmlAttributes;

		public ListBoxComponent(ITermResolver termResolver, CultureInfo culture, IEnumerable<TData> items,
			Func<TData, TPropertyInner> propValueFunc, Func<TData, string> itemValueFunc, Func<TData, string> itemTextFunc, Func<TData, object> itemHtmlAttributes)
			: base(termResolver, culture)
		{
			if (items == null)
				throw new ArgumentNullException(nameof(items), "DropDown's data items enumerable cannot be null");

			this.items = items;
			this.propValueFunc = propValueFunc;
			this.itemValueFunc = itemValueFunc;
			this.itemTextFunc = itemTextFunc;
			this.itemHtmlAttributes = itemHtmlAttributes;

			this.WithSize(5);
		}

		public override string ControlPrefix => "lst";

		/// <summary>
		/// Sets the size of the list box (in rows)
		/// </summary>
		/// <returns></returns>
		public virtual IListBoxComponent WithSize(int size)
		{
			this.WithAttr("size", size);
			return this;
		}
		/// <summary>
		/// Sets the size of the list box (in rows)
		/// </summary>
		/// <returns></returns>
		public virtual IListBoxComponent AllowMultiple()
		{
			this.WithAttr("multiple", new HtmlProperty());
			return this;
		}
		
		protected override string RenderComponent()
		{
			var builder = new TagBuilder("select", this.htmlAttributes);

			if (this.ariaLabel)
				this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(this.Label, this.culture));

			this.AddAriaDescribedBy();

			var haveSetSelected = false;

			foreach (var item in items)
			{
				var optionAttributes = this.itemHtmlAttributes?.Invoke(item);

				var optionBuilder = new TagBuilder("option", optionAttributes);

				optionBuilder.HtmlAttributes.Add("value", this.itemValueFunc.Invoke(item));

				if (!ReferenceEquals(this.value, null))
				{
					if (this.value.Contains(this.propValueFunc(item)) && (this.GetAttr("multiple") != null || !haveSetSelected))
					{
						optionBuilder.HtmlAttributes.Add("selected", new HtmlProperty());
						haveSetSelected = true;
					}
				}

				optionBuilder.SetInnerText(this.itemTextFunc.Invoke(item));

				builder.InnerHtml += optionBuilder.ToString();
			}

			return builder.ToString();
		}
	}
}