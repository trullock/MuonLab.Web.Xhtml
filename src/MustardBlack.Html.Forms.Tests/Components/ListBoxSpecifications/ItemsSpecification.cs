using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests.Components.ListBoxSpecifications
{
	public class ItemsSpecification : ListBoxComponentSpecification
	{
		protected override void When()
		{
		}

		protected override IEnumerable<Guid> Items => new [] { Guid.Parse("2008BC01-C2AE-43CD-AA91-FDA8592E5B1A"), Guid.Parse("1A3521DF-8B2B-4AC5-A624-9D819A1F3CBD")};
		protected override string ExpectedRendering => "<select size=\"5\">" +
		                                               "<option value=\"2008bc01-c2ae-43cd-aa91-fda8592e5b1a\">2008bc01-c2ae-43cd-aa91-fda8592e5b1a</option>" +
		                                               "<option value=\"1a3521df-8b2b-4ac5-a624-9d819a1f3cbd\">1a3521df-8b2b-4ac5-a624-9d819a1f3cbd</option>" +
		                                               "</select>";
	}
}