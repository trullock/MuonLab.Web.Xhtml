using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public abstract class WithClassSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IHiddenFieldComponent, new()
    {
        protected override void When()
        {
            component.WithClass("firstclass").AddClass("additional class").WithClass("theclass");
        }

        [Then]
        public void TheClassShouldBeSetCorrectly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}