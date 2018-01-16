using MustardBlack.Html;
using MustardBlack.Html.Components;

namespace MustardBlack.Html.Configuration
{
	public class DefaultFormConfiguration : FormConfiguration
	{
		public DefaultFormConfiguration()
		{
			Configure<IVisibleComponent>(c =>
				{
					c.WithRenderingOrder(ComponentPart.WrapperStartTag, ComponentPart.Label, ComponentPart.Component, ComponentPart.HelpText, ComponentPart.WrapperEndTag);
					c.WithLabel();
				});
		}
	}
}