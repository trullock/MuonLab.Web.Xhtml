using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.NumberBoxSpecifications.Aria
{
	public class NoAriaLabelSpecification : VisibleComponentSpecification<NumberBoxComponent<TestEntity, float>>
	{
	    protected override void When()
	    {
		    component
				//.WithAria()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"number\" value=\"0\" />";
    }
}