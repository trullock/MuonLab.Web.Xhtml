using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.PasswordBoxSpecificaitons.Aria
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