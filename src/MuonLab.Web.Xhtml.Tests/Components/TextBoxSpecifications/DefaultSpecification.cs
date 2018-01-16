using System;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.TextBoxSpecifications
{
	public class DefaultSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"text\" />";
	}
}