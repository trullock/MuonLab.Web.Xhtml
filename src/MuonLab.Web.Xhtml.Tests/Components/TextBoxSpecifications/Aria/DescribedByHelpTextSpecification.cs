using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.Aria
{
	public class DescribedByHelpTextSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void Given()
	    {
		    base.Given();

		    this.component.WithRenderingOrder(ComponentPart.HelpText, ComponentPart.Component);

		    Dependency<ITermResolver>()
			    .ResolveTerm("help", this.culture)
			    .Returns("help me");
		}

	    protected override void When()
	    {
		    component
			    .WithAria()
				.WithHelpText("help")
			    .WithId("txtTest");
	    }

        protected override string expectedRendering => "<span id=\"txtTest_Help\" class=\"field-help-text\">help me</span><input type=\"text\" id=\"txtTest\" aria-describedby=\"txtTest_Help\" />";
    }
}