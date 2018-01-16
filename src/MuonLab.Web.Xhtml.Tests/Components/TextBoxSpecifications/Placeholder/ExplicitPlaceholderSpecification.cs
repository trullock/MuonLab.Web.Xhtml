using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.Placeholder
{
	public class ExplicitPlaceholderSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    Dependency<ITermResolver>()
			    .ResolveTerm("explicit", this.culture)
			    .Returns("resolved");
	    }

	    protected override void When()
        {
			component
				.WithExplicitPlaceholder("explicit");
        }

        protected override string expectedRendering => "<input type=\"text\" placeholder=\"explicit\" />";
    }
}