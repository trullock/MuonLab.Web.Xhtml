using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.PasswordBoxSpecificaitons.Autocomplete
{
	public class AllowAutocompletionSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
    {
        protected override void When()
        {
            component
	            .PreventAutoComplete()
	            .AllowAutoComplete();
        }

        protected override string expectedRendering => "<input type=\"password\" />";
    }
}