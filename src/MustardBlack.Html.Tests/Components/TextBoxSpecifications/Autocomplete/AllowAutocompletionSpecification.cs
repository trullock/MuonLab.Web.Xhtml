using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.TextBoxSpecifications.Autocomplete
{
	public class AllowAutocompletionSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, string>>
    {
        protected override void When()
        {
            component
	            .PreventAutoComplete()
	            .AllowAutoComplete();
        }

        protected override string expectedRendering => "<input type=\"text\" />";
    }
}