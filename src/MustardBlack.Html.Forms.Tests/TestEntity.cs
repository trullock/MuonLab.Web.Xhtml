using System;
using System.Collections.Generic;

namespace MustardBlack.Html.Forms.Tests
{
	public class TestEntity
	{
		public string Property { get; set; }
		public DateTime Date { get; set; }
		public IEnumerable<Guid> Items { get; set; }
	}
}