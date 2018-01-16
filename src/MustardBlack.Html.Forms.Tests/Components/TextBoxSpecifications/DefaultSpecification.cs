using System;
using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Forms.Tests.Components.TextBoxSpecifications
{
	public class DefaultSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"text\" />";
	}
}