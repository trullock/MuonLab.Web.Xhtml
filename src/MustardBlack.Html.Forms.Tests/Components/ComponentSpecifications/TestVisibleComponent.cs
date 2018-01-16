using System.Globalization;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications
{
	public class TestVisibleComponent<TEntity, TProperty> : VisibleComponent<TEntity, TProperty> where TEntity : class
	{
		public TestVisibleComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
		{
		}

		public override string ControlPrefix => "ctrl";

		protected override string RenderComponent()
		{
			this.htmlAttributes["name"] = this.Name;
			var builder = new TagBuilder("test", this.htmlAttributes);
			return builder.ToString();
		}
	}
}