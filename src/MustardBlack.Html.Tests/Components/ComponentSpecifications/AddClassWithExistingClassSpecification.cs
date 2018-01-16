using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.ComponentSpecifications
{
    public class AddClassWithExistingClassSpecification : Specification
    {
		private IComponent component;

		protected override void Given()
		{
			this.component = new TestComponent<TestEntity, string>();
		}

    	protected override void When()
        {
            component = component.WithClass("firstclass").AddClass("additional class");
        }

        [Then]
        public void TheClassShouldBeSetCorrectly()
        {
            component.ToString().ShouldEqual("<test class=\"firstclass additional class\"></test>");
        }
    }
}