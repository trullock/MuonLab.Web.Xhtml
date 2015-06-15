using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class RadioButtonListComponent<TViewModel, TProperty, TData> :
		VisibleComponent<TViewModel, TProperty>,
		IRadioButtonListComponent<TProperty>
    {
    	readonly IEnumerable<TData> items;
    	readonly Func<TData, string> valueFunc;
    	readonly Func<TData, string> textFunc;

    	public override string ControlPrefix
        {
            get { return "rb"; }
        }

	    public RadioButtonListComponent(ITermResolver termResolver, CultureInfo culture, IEnumerable<TData> items, Func<TData, string> valueFunc, Func<TData, string> textFunc) : base(termResolver, culture)
	    {
		    this.items = items;
		    this.valueFunc = valueFunc;
		    this.textFunc = textFunc;
	    }

	    protected override string RenderComponent()
        {
    		var stringBuilder = new StringBuilder();

    		var i = 0;
    		foreach(var item in items)
    		{
    			stringBuilder.Append("<div>");

				var checkbox = new TagBuilder("input", this.htmlAttributes);
    			var id = checkbox.HtmlAttributes["id"] + "_" + i;
    			checkbox.HtmlAttributes["id"] = id;
				checkbox.HtmlAttributes.Add("type", "radio");
				checkbox.HtmlAttributes.Add("value", valueFunc(item));

    			if (Equals(value, item))
    				checkbox.HtmlAttributes.Add("checked", "checked");

    			stringBuilder.Append(checkbox.ToString());

				var label = new TagBuilder("label", new { @for = id});
				label.SetInnerText(this.termResolver.ResolveTerm(textFunc(item), this.culture));

    			stringBuilder.Append(label);

    			stringBuilder.Append("</div>");
    			i++;
    		}

    		return stringBuilder.ToString();
        }
    }
}