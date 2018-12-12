namespace MustardBlack.Html.Forms.Tests.TagBuilderSpecs
{
	public class ToString : Specification
	{
		TagBuilder subject;
		string toString;

		protected override void Given()
		{
			subject = new TagBuilder("div", new
			{
				id = "#id",
				@class = "class1 class2",
				data_foo = "\"bar\""
			});
		}

		protected override void When()
		{
			toString = this.subject.ToString();
		}

		[Then]
		public void ShouldToStringProperly()
		{
			this.toString.ShouldEqual("<div id=\"#id\" class=\"class1 class2\" data-foo=\"&quot;bar&quot;\"></div>");
		}
	}
}