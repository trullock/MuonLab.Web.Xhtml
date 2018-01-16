using System;
using System.Web;

namespace MustardBlack.Html.Forms
{
	public static class HtmlEncoder
	{
		public static Func<object, string> HtmlEncodeFunc = s => HttpUtility.HtmlEncode(s);
		public static Func<object, string> HtmlAttributeEncodeFunc = s => HttpUtility.HtmlAttributeEncode(s.ToString());
		public static string HtmlEncode(object input) => HtmlEncodeFunc(input);
		public static string HtmlAttributeEncode(object input) => HtmlAttributeEncodeFunc(input);
	}
}