using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class AllowAutocompletionSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, string>>
    {
        protected override void When()
        {
            component.PreventAutoComplete().AllowAutoComplete().WithRenderingOrder(ComponentPart.Component);
        }

        protected override string expectedRendering => "<input type=\"text\" />";

	    [Then]
        public void the_prevent_auto_completion_atrribute_should_not_be_rendered()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}