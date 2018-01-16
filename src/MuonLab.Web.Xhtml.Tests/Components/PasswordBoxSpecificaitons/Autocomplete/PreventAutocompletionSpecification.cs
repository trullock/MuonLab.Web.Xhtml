using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.PasswordBoxSpecificaitons.Autocomplete
{
	public class PreventAutocompletionSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
    {
        protected override void When()
        {
            component.PreventAutoComplete();
        }

        protected override string expectedRendering => "<input type=\"password\" autocomplete=\"off\" />";

    }
}