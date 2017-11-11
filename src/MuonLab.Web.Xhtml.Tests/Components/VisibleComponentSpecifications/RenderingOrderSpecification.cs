using System.Globalization;
using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Components.Implementations;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Tests.Components.VisibleComponentSpecifications
{
	public class RenderingOrderSpecification : Specification
	{
		IVisibleComponent component;

		protected override void Given()
		{
			var culture = new CultureInfo("en-GB");
			component = new TestComponent<TestEntity, string>(this.Dependency<ITermResolver>(), culture).WithRenderingOrder(ComponentPart.Label, ComponentPart.WrapperStartTag, ComponentPart.Component, ComponentPart.ValidationMessage, ComponentPart.HelpText, ComponentPart.WrapperEndTag);
		}

		protected override void When()
		{
			component.WithLabel().WithHelpText("helptext");
		}

		[Then]
		public void the_parts_should_be_rendered_in_the_right_order()
		{
			component.ToString().ShouldEqual("labelwrapperstarttagcomponentvalidationmessagehelptextwrapperendtag");
		}

		class TestComponent<TEntity, TProperty> : VisibleComponent<TEntity, TProperty> where TEntity : class
		{
			public TestComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
			{
			}

			public override string ControlPrefix
			{
				get { return "ctrl"; }
			}

			protected override string RenderComponent()
			{
				return "component";
			}

			protected override string RenderLabel()
			{
				return "label";
			}

			protected override string RenderValidationMessage()
			{
				return "validationmessage";
			}

			protected override string RenderHelpText()
			{
				return "helptext";
			}

			protected override string RenderWrapperEndTag()
			{
				return "wrapperendtag";
			}

			protected override string RenderWrapperStartTag()
			{
				return "wrapperstarttag";
			}
		}

		class TestEntity
		{
			public string Property { get; set; }
		}
	}
}