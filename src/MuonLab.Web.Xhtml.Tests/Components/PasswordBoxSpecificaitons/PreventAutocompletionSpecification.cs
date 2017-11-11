using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications;

namespace MuonLab.Web.Xhtml.Tests.Components.PasswordBoxSpecificaitons
{
	public class PreventAutocompletionSpecification : VisibleComponentSpecification<PasswordBoxComponent<TestEntity>>
	{
		protected override void When()
		{
			this.component.PreventAutoComplete().WithRenderingOrder(ComponentPart.Component);
		}

		protected override string expectedRendering => "<input type=\"password\" autocomplete=\"off\" />";

		[Then]
		public void the_prevent_auto_completion_atrribute_should_be_rendered()
		{
			this.component.ToString().ShouldEqual(this.expectedRendering);
		}
	}
}