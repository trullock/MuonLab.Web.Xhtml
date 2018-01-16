using NSubstitute;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public class WithLabelSpecification : VisibleComponentSpecification<TestVisibleComponent<TestEntity, string>>
    {
		protected override void Given()
		{
			base.Given();

			this.termResolver.ResolveTerm("thelabel", this.culture).Returns("the label");

			component.WithRenderingOrder(ComponentPart.Label);
		}

		protected override string expectedRendering => "<label for=\"theid\">the label</label>";

	    protected override void When()
        {
			component.WithLabel("thelabel").WithId("theid");
        }

        [Then]
        public void TheLabelShouldBeRenderedCorrectly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}