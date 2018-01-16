using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.Autocomplete
{
	public class PreventAutocompletionSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, string>>
    {
        protected override void When()
        {
            component.PreventAutoComplete();
        }

        protected override string expectedRendering => "<input type=\"text\" autocomplete=\"off\" />";

    }
}