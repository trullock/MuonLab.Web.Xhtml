using System;
using System.Globalization;
using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Tests.Components.ComponentSpecifications
{
	public abstract class VisibleComponentSpecification<TComponent> : Specification where TComponent : IVisibleComponent
	{
        protected TComponent component;

		protected override void Given()
		{
			this.component = (TComponent)Activator.CreateInstance(typeof(TComponent), this.Dependency<ITermResolver>(), new CultureInfo("en-GB"));
		}

		protected abstract string expectedRendering { get; }
	}
}