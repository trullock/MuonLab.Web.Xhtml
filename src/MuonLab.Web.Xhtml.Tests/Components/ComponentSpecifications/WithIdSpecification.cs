using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications
{
	public abstract class WithIdSpecification<TComponent> : HiddenComponentSpecification<TComponent> where TComponent : IHiddenFieldComponent, new()
	{
        protected override void When()
        {
            component.WithId("theid");
        }

        [Then]
        public void the_id_should_be_set_correctly()
        {
            component.ToString().ShouldEqual(expectedRendering);
        }
    }
}