using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MustardBlack.Html
{
    public class TagBuilder
    {
    	public string TagName { get; set; }
        public IDictionary<string, object> HtmlAttributes { get; set; }
        public string InnerHtml { get; set; }
		
		public TagBuilder(string tagname, object htmlAttributes = null) : this(tagname, (htmlAttributes ?? new {}).ToDictionary())
		{
		}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="tagname">The tag name</param>
        /// <param name="htmlAttributes">A dictionary of html attributes. Values get HtmlEncoded.</param>
        public TagBuilder(string tagname, IDictionary<string, object> htmlAttributes)
        {
            this.TagName = tagname;
            this.HtmlAttributes = htmlAttributes == null ? new Dictionary<string, object>() : new Dictionary<string, object>(htmlAttributes);
        }

		public void SetInnerText(string text)
		{
			// Do not remove coding without prior discussion
			this.InnerHtml = HtmlEncoder.HtmlEncode(text);
		}

        public override string ToString()
        {
            var builder = new StringBuilder();

            RenderStart(builder);

        	var tagUpper = this.TagName.ToUpper();
        	if (tagUpper != "INPUT")
            {
				builder
                    .Append('>')
                    .Append(InnerHtml)
                    .Append("</")
                    .Append(TagName)
                    .Append('>');
            }
            else
                builder.Append(" />");

            return builder.ToString();
        }

    	void RenderStart(StringBuilder builder)
		{
			builder.Append('<').Append(TagName);
			foreach (var key in OrderedHtmlAttributeKeys)
			{
				var encoded = HtmlEncode(this.HtmlAttributes[key]);
				if(encoded != null)
					builder.Append($" {key}=\"{encoded}\"");
			}
		}

    	static string HtmlEncode(object value)
		{
			if(value == null)
				return null;

			var stringValue = value.ToString();

			return HtmlEncoder.HtmlAttributeEncode(stringValue);
		}

		// TODO: Improve this!
		protected IEnumerable<string> OrderedHtmlAttributeKeys
		{
			get
			{
				return this.HtmlAttributes.Keys.OrderBy(k =>
				{
					switch (k.ToUpper())
					{
						case "TYPE":
							return ".";
						case "ID":
							return "..";
						case "NAME":
							return "...";
						default:
							return k;
					}
				});
			}
		}

    	public string ToString(TagRenderMode mode)
    	{
    	    if(mode == TagRenderMode.StartTag)
    		{
				var builder = new StringBuilder();
				RenderStart(builder);
    			builder.Append('>');
    			return builder.ToString();
    		}
    	
            return "</" + this.TagName + ">";
    	}
    }
}