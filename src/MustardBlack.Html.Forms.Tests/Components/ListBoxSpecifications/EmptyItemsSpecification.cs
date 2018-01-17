using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.Components.ListBoxSpecifications
{
	public class EmptyItemsSpecification : ListBoxComponentSpecification
	{
		protected override void When()
		{
		}

		protected override IEnumerable<Guid> Items => new Guid[0];
		protected override string ExpectedRendering => "<select size=\"5\"></select>";
	}
}