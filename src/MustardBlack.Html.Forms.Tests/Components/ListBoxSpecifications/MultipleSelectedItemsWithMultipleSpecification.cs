using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.Components.ListBoxSpecifications
{
	public class MultipleSelectedItemsWithMultipleSpecification : ListBoxComponentSpecification
	{
		Guid item1;
		Guid item2;

		protected override void Given()
		{
			this.item1 = Guid.Parse("2008BC01-C2AE-43CD-AA91-FDA8592E5B1A");
			this.item2 = Guid.Parse("1A3521DF-8B2B-4AC5-A624-9D819A1F3CBD");

			base.Given();

			this.component.AllowMultiple();
		}

		protected override void When()
		{
			component.WithValue(new[] {item1, item2});
		}

		protected override IEnumerable<Guid> Items => new [] { item1, item2};
		protected override string ExpectedRendering => "<select size=\"5\">" +
		                                               "<option selected value=\"2008bc01-c2ae-43cd-aa91-fda8592e5b1a\">2008bc01-c2ae-43cd-aa91-fda8592e5b1a</option>" +
		                                               "<option selected value=\"1a3521df-8b2b-4ac5-a624-9d819a1f3cbd\">1a3521df-8b2b-4ac5-a624-9d819a1f3cbd</option>" +
		                                               "</select>";
	}
}