using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public abstract class WithValueAttributeSpecification<TComponent, TProperty> : ComponentTSpecification<TComponent, TProperty> where TComponent : IComponent<TProperty>, new()
	{
		protected abstract TProperty value { get; }

		protected override void When()
		{
			component = component.WithValue(value);
		}

		[Then]
		public void TheValueShouldBeSetCorrectly()
		{
			component.ToString().ShouldEqual(expectedRendering);
		}
	}
}