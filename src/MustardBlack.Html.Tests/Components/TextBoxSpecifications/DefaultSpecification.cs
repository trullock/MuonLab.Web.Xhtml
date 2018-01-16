using System;
using MustardBlack.Html.Components;
using MustardBlack.Html.Tests.Components.ComponentSpecifications;

namespace MustardBlack.Html.Tests.Components.TextBoxSpecifications
{
	public class DefaultSpecification : VisibleComponentSpecification<TextBoxComponent<TestEntity, DateTime?>>
	{
		protected override void When()
		{
		}

		protected override string expectedRendering => "<input type=\"text\" />";
	}
}