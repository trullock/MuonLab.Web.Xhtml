using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
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