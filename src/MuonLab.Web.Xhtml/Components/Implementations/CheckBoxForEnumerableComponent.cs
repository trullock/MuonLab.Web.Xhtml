using System.Collections.Generic;
using System.Linq;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
	public class CheckBoxForEnumerableComponent<TViewModel, TInner> :
		VisibleComponent<TViewModel, IEnumerable<TInner>>,
		ICheckBoxComponent<IEnumerable<TInner>>
    {
		readonly TInner innerValue;

		public CheckBoxForEnumerableComponent(TInner innerValue)
		{
			this.innerValue = innerValue;
		}

		public override string ControlPrefix
        {
            get { return "chk"; }
        }

    	protected override string RenderComponent()
        {
            var checkbox = new TagBuilder("input", this.htmlAttributes);
            checkbox.HtmlAttributes.Add("type", "checkbox");
            checkbox.HtmlAttributes.Add("value", this.innerValue);

            if(this.value.Contains(this.innerValue))
                checkbox.HtmlAttributes.Add("checked", "checked");

            return checkbox.ToString();
        }
    }
}