using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.PasswordBoxSpecificaitons.Autocomplete
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