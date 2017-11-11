using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications
{
	public abstract class WithClassSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IHiddenFieldComponent, new()
    {
        protected override void When()
        {
            component.WithClass("firstclass").AddClass("additional class").WithClass("theclass");
        }

        [Then]
        public void the_class_should_be_set_correctly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}