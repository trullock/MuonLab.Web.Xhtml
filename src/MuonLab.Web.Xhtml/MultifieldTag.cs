namespace MuonLab.Web.Xhtml
{
	public sealed class MultifieldTag
#if NET46
        : System.Web.IHtmlString
#endif
	{
		readonly string contents;

		public MultifieldTag(string contents)
		{
			this.contents = contents;
		}

		public string ToString()
		{
			return this.contents;
		}
#if NET46
		public string ToHtmlString()
		{
			return this.contents;
		}
#endif
	}
}