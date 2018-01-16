using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.ComponentSpecifications
{
	public abstract class ComponentTSpecification<TComponent, TProperty> : Specification where TComponent : IComponent<TProperty>, new()
	{
		protected IComponent<TProperty> component;

		protected override void Given()
		{
			this.component = new TComponent();
		}

		public abstract string expectedRendering { get; }
	}
}