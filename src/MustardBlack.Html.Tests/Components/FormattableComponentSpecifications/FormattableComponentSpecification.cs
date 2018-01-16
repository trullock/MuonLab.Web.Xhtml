using System;
using System.Globalization;
using MustardBlack.Html.Components;
using MustardBlack.Html.Configuration;

namespace MustardBlack.Html.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormattableComponentSpecification<TComponent> : Specification where TComponent : IFormattableComponent
    {
        protected IFormattableComponent component;

        protected override void Given()
        {
			this.component = (TComponent)Activator.CreateInstance(typeof(TComponent), Dependency<ITermResolver>(), new CultureInfo("en-GB"));
			if (this.component is IVisibleComponent)
				((IVisibleComponent)component).WithRenderingOrder(ComponentPart.Component);
        }

        protected abstract string expectedRendering { get; }
    }
}