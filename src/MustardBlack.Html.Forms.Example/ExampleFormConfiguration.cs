using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Example
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