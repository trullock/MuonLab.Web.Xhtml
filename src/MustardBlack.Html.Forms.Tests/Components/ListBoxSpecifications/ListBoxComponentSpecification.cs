using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Tests.Components.ListBoxSpecifications
{
	public abstract class ListBoxComponentSpecification : Specification
	{
        protected ListBoxComponent<TestEntity, IEnumerable<Guid>, Guid> component;
		protected CultureInfo culture;
		protected ITermResolver termResolver;

		protected override void Given()
		{
			culture = new CultureInfo("en-GB");
			termResolver = this.Dependency<ITermResolver>();
			this.component = new ListBoxComponent<TestEntity, IEnumerable<Guid>, Guid>(termResolver, this.culture, this.Items, g => g.ToString(), g => g.ToString(), null);
			this.component.WithRenderingOrder(ComponentPart.Component);
		}
		
		protected abstract IEnumerable<Guid> Items { get; }
		protected abstract string ExpectedRendering { get; }

		[Then]
		public void TheCorrectMarkupShouldBeRendered()
		{
			component.ToString().ShouldEqual(ExpectedRendering);
		}
	}
}