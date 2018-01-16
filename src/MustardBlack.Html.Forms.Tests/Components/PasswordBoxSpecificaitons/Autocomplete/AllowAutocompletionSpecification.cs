using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.PasswordBoxSpecificaitons.Autocomplete
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