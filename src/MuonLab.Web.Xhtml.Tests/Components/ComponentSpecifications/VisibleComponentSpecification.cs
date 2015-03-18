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
		protected CultureInfo culture;
		protected ITermResolver termResolver;

		protected override void Given()
		{
			culture = new CultureInfo("en-GB");
			termResolver = this.Dependency<ITermResolver>();
			this.component = (TComponent)Activator.CreateInstance(typeof(TComponent), termResolver, culture);
		}

		protected abstract string expectedRendering { get; }
	}
}