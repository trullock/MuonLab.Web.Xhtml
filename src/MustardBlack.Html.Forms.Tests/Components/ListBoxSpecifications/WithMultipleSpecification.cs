using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.Components.ListBoxSpecifications
{
	public class WithMultipleSpecification : ListBoxComponentSpecification
	{
		protected override void When()
		{
			component.AllowMultiple();
		}

		protected override IEnumerable<Guid> Items => new Guid[0];
		protected override string ExpectedRendering => "<select multiple size=\"5\"></select>";
	}
}