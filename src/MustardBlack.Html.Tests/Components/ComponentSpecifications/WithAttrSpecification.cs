using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.ComponentSpecifications
{
	public abstract class WithAttrSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IHiddenFieldComponent, new()
    {
        protected override void When()
        {
            component.WithAttr("misc", "random");
        }

        [Then]
        public void TheMiscAttrShouldBeSetCorrectlyAndTheNameShouldntBeOverridden()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}