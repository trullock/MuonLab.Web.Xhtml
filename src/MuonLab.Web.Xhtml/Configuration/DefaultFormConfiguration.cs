using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Configuration
{
	public class DefaultFormConfiguration : FormConfiguration
	{
		public DefaultFormConfiguration()
		{
			Configure<IVisibleComponent>(c =>
				{
					c.WithRenderingOrder(ComponentPart.WrapperStartTag, ComponentPart.Label, ComponentPart.Component, ComponentPart.ValidationMarker, ComponentPart.HelpText, ComponentPart.WrapperEndTag);
					c.WithLabel();
					c.WithValidationMarker(ValidationMarkerMode.OnError);
				});

		}
	}
}