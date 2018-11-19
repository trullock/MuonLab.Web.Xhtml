namespace MustardBlack.Html.Forms
{
	public sealed class MultifieldTag : System.Web.IHtmlString

	{
		readonly string contents;

		public MultifieldTag(string contents)
		{
			this.contents = contents;
		}

		public override string ToString()
		{
			return this.contents;
		}

		public string ToHtmlString()
		{
			return this.contents;
		}

	}
}