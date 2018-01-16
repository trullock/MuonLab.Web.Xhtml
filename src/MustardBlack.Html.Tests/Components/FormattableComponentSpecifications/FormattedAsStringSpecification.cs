using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormattedAsStringSpecification<TComponent, TProperty> : FormattableComponentSpecification<TComponent> where TComponent : IFormattableComponent
    {
        protected override void When()
        {
            component = component.FormattedAs(formatString).WithValue(value) as IFormattableComponent;
        }

        protected abstract TProperty value { get; }
        protected abstract string formatString { get; }

        [Then]
        public void TheCorrectMarkupShouldBeRendered()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}