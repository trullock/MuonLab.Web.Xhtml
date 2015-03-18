using MuonLab.Testing;
using Rhino.Mocks;

namespace MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications
{
	public class WithLabelSpecification : VisibleComponentSpecification<TestVisibleComponent<TestEntity, string>>
    {
		protected override void Given()
		{
			base.Given();

			this.termResolver.Stub(r => r.ResolveTerm("thelabel", this.culture)).Return("the label");

			component.WithRenderingOrder(ComponentPart.Label);
		}

		protected override string expectedRendering
		{
			get { return "<label for=\"theid\">the label</label>"; }
		}

		protected override void When()
        {
			component.WithLabel("thelabel").WithId("theid");
        }

        [Then]
        public void the_label_should_be_rendered_correctly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}