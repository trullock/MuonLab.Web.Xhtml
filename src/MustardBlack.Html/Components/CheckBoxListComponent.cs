using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MustardBlack.Html.Configuration;

namespace MustardBlack.Html.Components
{
	public class CheckBoxListComponent<TViewModel, TProperty, TData> : VisibleComponent<TViewModel, TProperty>, ICheckBoxListComponent<TProperty>
	{
		readonly IEnumerable<TData> items;
		readonly Func<TData, string> valueFunc;
		readonly Func<TData, string> textFunc;
		readonly Func<TProperty, TData, bool> itemIsValue;

		string tickAll;

		public override string ControlPrefix => "chk";

		public CheckBoxListComponent(ITermResolver termResolver, CultureInfo culture, IEnumerable<TData> items,
			Func<TData, string> valueFunc, Func<TData, string> textFunc, Func<TProperty, TData, bool> itemIsValue)
			: base(termResolver, culture)
		{
			this.items = items;
			this.valueFunc = valueFunc;
			this.textFunc = textFunc;
			this.itemIsValue = itemIsValue;
		}

		protected override string RenderComponent()
		{
			var stringBuilder = new StringBuilder();

			if (this.tickAll != null)
			{
				var allTicked = this.items.All(item => itemIsValue(value, item));

				stringBuilder.Append("<div class=\"tickAll\">");

				var checkbox = new TagBuilder("input", this.htmlAttributes);
				checkbox.HtmlAttributes["class"] = checkbox.HtmlAttributes.ContainsKey("class")
					? checkbox.HtmlAttributes["class"] + " tickAll"
					: "tickAll";

				if (checkbox.HtmlAttributes.ContainsKey("name"))
					checkbox.HtmlAttributes.Remove("name");

				var id = checkbox.HtmlAttributes["id"] + "_all";
				checkbox.HtmlAttributes["id"] = id;
				checkbox.HtmlAttributes.Add("type", "checkbox");
				checkbox.HtmlAttributes.Add("value", "");

				if (allTicked)
					checkbox.HtmlAttributes.Add("checked", "checked");

				stringBuilder.Append(checkbox);

				var label = new TagBuilder("label", new {@for = id});
				label.SetInnerText(this.tickAll);
				stringBuilder.Append(label);

				stringBuilder.Append("</div>");
			}

			var i = 0;
			foreach (var item in items)
			{
				stringBuilder.Append("<div>");

				var checkbox = new TagBuilder("input", this.htmlAttributes);
				var id = checkbox.HtmlAttributes["id"] + "_" + i;
				checkbox.HtmlAttributes["id"] = id;
				checkbox.HtmlAttributes.Add("type", "checkbox");
				checkbox.HtmlAttributes.Add("value", valueFunc(item));

				if (itemIsValue(value, item))
					checkbox.HtmlAttributes.Add("checked", "checked");

				if(this.ariaLabel)
					checkbox.HtmlAttributes.Add("aria-label", textFunc(item));

				stringBuilder.Append(checkbox);

				var label = new TagBuilder("label", new {@for = id});
				label.SetInnerText(textFunc(item));

				stringBuilder.Append(label);

				stringBuilder.Append("</div>");
				i++;
			}

			return stringBuilder.ToString();
		}

		public ICheckBoxListComponent WithTickAll()
		{
			this.tickAll = "(Tick All)";
			return this;
		}

		public ICheckBoxListComponent WithTickAll(string label)
		{
			this.tickAll = label;
			return this;
		}
	}
}