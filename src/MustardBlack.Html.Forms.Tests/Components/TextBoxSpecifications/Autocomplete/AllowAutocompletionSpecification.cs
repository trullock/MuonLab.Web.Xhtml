using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Autocomplete
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