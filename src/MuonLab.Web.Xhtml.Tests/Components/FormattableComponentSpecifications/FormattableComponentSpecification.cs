using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormattableComponentSpecification<TComponent> : Specification where TComponent : IFormattableComponent, new()
    {
        protected IFormattableComponent component;

        protected override void Given()
        {
			this.component = new TComponent();
			if (this.component is IVisibleComponent)
				((IVisibleComponent)component).WithRenderingOrder(ComponentPart.Component);
        }

        protected abstract string expectedRendering { get; }
    }
}