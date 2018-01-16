using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.ComponentSpecifications
{
	public abstract class DisabledSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IComponent, new()
	{
        protected override void When()
        {
            component.Disabled();
        }

        [Then]
        public void TheDisabledAttrShouldBeSet()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
	}
}