using System;
using System.Collections.Generic;
using System.Globalization;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Tests.Components.DropDownSpecifications
{
	public abstract class DropDownBoxComponentWithAttributesSpecification : Specification
	{
        protected DropDownComponent<TestEntity, Guid, TestClass> component;
		protected CultureInfo culture;
		protected ITermResolver termResolver;
		ValidationMessageRenderer validationMessageRenderer;

		protected override void Given()
		{
			this.culture = new CultureInfo("en-GB");
			this.termResolver = this.Dependency<ITermResolver>();
			
			this.validationMessageRenderer = new ValidationMessageRenderer();
			this.component = new DropDownComponent<TestEntity, Guid, TestClass>(this.termResolver, this.validationMessageRenderer, this.culture, this.Items, g => g.ToString(), g => g.Guid, g => g.Guid.ToString(), i => null);
			this.component.WithRenderingOrder(ComponentPart.Component);
			this.component.WithLabel("Test Class");
			this.component.WithAria();
		}
		
		protected abstract IEnumerable<TestClass> Items { get; }
		protected abstract string ExpectedRendering { get; }

		[Then]
		public void TheCorrectMarkupShouldBeRendered()
		{
			this.component.ToString().ShouldEqual(this.ExpectedRendering);
		}
	}
}