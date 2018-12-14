using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.PasswordBoxSpecificaitons.Autocomplete
{
	public class AutoCompleteSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
    {
        protected override void When()
        {
	        component
		        .WithAutoComplete("foo");
        }

        protected override string expectedRendering => "<input type=\"password\" autocomplete=\"foo\" />";
    }
}