using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	public class ExampleFormConfiguration : DefaultFormConfiguration
	{
		public ExampleFormConfiguration()
		{
			this.Configure<IVisibleComponent>(c => c.WithWrapper("div", new { @class = "field"}));
			
			this.Configure<ITextBoxComponent<int>>(c => c.WithAttr("maxlength", "2"));
		}
	}
}