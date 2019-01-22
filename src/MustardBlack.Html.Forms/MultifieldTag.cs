using System.IO;
using Microsoft.AspNetCore.Html;

namespace MustardBlack.Html.Forms
{
	public sealed class MultifieldTag : IHtmlContent
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

		public void WriteTo(TextWriter writer, System.Text.Encodings.Web.HtmlEncoder encoder)
		{
			writer.Write(this.ToString());
		}
	}
}