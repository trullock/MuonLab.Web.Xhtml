using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.Components.DropDownSpecifications
{
	public class EmptyItemsSpecification : DropDownBoxComponentSpecification
	{
		protected override void When()
		{
		}

		protected override IEnumerable<TestClass> Items => new TestClass[0];
		protected override string ExpectedRendering => "<select></select>";
	}
}