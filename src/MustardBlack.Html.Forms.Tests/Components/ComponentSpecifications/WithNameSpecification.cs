using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public abstract class WithNameSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IHiddenFieldComponent, new()
    {
        protected override void When()
        {
            component.WithName("thename");
        }

        [Then]
        public void TheNameShouldBeSetCorrectly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}