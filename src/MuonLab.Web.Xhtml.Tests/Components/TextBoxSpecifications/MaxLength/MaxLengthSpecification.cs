using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications.MaxLength
{
	public class MaxLengthSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
    {
	    protected override void When()
	    {
		    component
			    .WithMaxLength(15);
	    }

        protected override string expectedRendering => "<input type=\"text\" maxlength=\"15\" />";
    }
}