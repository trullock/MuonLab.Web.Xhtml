using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.PasswordBoxSpecificaitons.Aria
{
	public class NoAriaLabelSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
    {
	    protected override void When()
	    {
		    component
				//.WithAria()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"password\" />";
    }
}