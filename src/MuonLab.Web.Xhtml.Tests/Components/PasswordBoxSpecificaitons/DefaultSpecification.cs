using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.PasswordBoxSpecificaitons
{
	public class DefaultSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"password\" />";
	}
}