using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.ComponentSpecifications
{
	public class WithAttrForNameSpecification : Specification
	{
		private IComponent component;

		protected override void Given()
		{
			this.component = new TestComponent<TestEntity, string>();
		}

		protected override void When()
        {
			component = component
				.WithName("name")
				.WithAttr("name", "other")
				.WithAttr("misc", "random");
        }

		[Then]
		public void TheMiscAttrShouldBeSetCorrectlyAndTheNameShouldBeOverridden()
		{
			component.ToString().ShouldEqual("<test name=\"other\" misc=\"random\"></test>");
		}
	}
}