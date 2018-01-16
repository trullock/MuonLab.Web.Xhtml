using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.Aria
{
	public class AriaLabelSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    Dependency<ITermResolver>()
			    .ResolveTerm("label", this.culture)
			    .Returns("resolved");
	    }

	    protected override void When()
	    {
		    component
				.WithAria()
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" aria-label=\"resolved\" />";
    }
}