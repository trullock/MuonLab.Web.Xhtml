using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications.Placeholder
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