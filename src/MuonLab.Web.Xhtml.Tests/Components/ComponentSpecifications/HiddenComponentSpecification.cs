using System;
using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications
{
	public abstract class HiddenComponentSpecification<TComponent> : Specification where TComponent : IComponent
	{
        protected TComponent component;

		protected override void Given()
		{
			this.component = (TComponent)Activator.CreateInstance(typeof(TComponent));
		}

		protected abstract string expectedRendering { get; }
	}
}