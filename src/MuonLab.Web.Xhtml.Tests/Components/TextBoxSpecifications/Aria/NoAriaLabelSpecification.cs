using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.Aria
{
	public class NoAriaLabelSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void When()
	    {
		    component
				//.WithAria()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" />";
    }
}