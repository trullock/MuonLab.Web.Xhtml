using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public abstract class WithIdSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IHiddenFieldComponent, new()
	{
        protected override void When()
        {
            component.WithId("theid");
        }

        [Then]
        public void TheIdShouldBeSetCorrectly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}