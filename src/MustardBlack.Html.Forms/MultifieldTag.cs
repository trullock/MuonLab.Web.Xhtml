namespace MustardBlack.Html.Forms
{
	public sealed class MultifieldTag
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
	}
}