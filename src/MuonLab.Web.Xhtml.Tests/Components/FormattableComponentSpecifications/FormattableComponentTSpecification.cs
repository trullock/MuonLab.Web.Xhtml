using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.FormattableComponentSpecifications
{
    public abstract class FormattableComponentTSpecification<TComponent, TProperty> : Specification where TComponent : IFormattableComponent<TProperty>, new()
    {
        protected IFormattableComponent<TProperty> component;

        protected override void Given()
        {
            this.component = new TComponent();
			if(this.component is IVisibleComponent)
				((IVisibleComponent)component).WithRenderingOrder(ComponentPart.Component);
        }

        protected abstract string expectedRendering { get; }
    }
}