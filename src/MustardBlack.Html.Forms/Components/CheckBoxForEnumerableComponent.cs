using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
	public class CheckBoxForEnumerableComponent<TViewModel, TInner> : VisibleComponent<TViewModel, IEnumerable<TInner>>, ICheckBoxComponent<IEnumerable<TInner>>
	{
		readonly TInner innerValue;

		public override string ControlPrefix => "chk";

		public CheckBoxForEnumerableComponent(ITermResolver termResolver, CultureInfo culture, TInner innerValue) : base(termResolver, culture)
		{
			this.innerValue = innerValue;
		}

		protected override string RenderComponent()
		{
			var checkbox = new TagBuilder("input", this.htmlAttributes);
			checkbox.HtmlAttributes.Add("type", "checkbox");
			checkbox.HtmlAttributes.Add("value", this.innerValue);

			if (this.value.Contains(this.innerValue))
				checkbox.HtmlAttributes.Add("checked", "checked");

			return checkbox.ToString();
		}
	}
}