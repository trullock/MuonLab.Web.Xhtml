using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Configuration
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