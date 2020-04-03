using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.NumberBoxSpecifications.Autocomplete
{
	public class MinMaxStepSpecification : VisibleComponentSpecification<NumberBoxComponent<TestEntity, float>>
    {
        protected override void When()
        {
            component.WithMaximum(10).WithMinimum(5).WithStep(0.1M);
        }

        protected override string expectedRendering => "<input type=\"number\" max=\"10\" min=\"5\" step=\"0.1\" value=\"0\" />";
    }
}