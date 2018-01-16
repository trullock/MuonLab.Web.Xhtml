using System;
using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormatWithSpecification<TComponent, TProperty> : FormattableComponentTSpecification<TComponent, TProperty> where TComponent : IFormattableComponent<TProperty>
    {
        protected override void When()
        {
            component = component.FormatWith(formatFunc).WithValue(value) as IFormattableComponent<TProperty>;
        }

        protected abstract TProperty value { get; }
        protected abstract Func<TProperty, string> formatFunc { get; }

        [Then]
        public void TheCorrectMarkupShouldBeRendered()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}