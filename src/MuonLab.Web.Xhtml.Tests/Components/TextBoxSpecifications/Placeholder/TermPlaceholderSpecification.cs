using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.Placeholder
{
	public class TermPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    Dependency<ITermResolver>()
			    .ResolveTerm("term", this.culture)
			    .Returns("resolved");
	    }

	    protected override void When()
	    {
		    component
			    .WithPlaceholder("term")
			    .WithLabel("label");
	    }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"resolved\" />";
    }
}