using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;

namespace MustardBlack.Html.Forms
{
    public class TagBuilder
    {
	    protected readonly HtmlEncoder encoder;
	    public string TagName { get; set; }
        public IDictionary<string, object> HtmlAttributes { get; set; }
        public string InnerHtml { get; set; }
		
		public TagBuilder(string tagName, object htmlAttributes = null, HtmlEncoder encoder = null) : this(tagName, (htmlAttributes ?? new {}).ToDictionary(), encoder)
		{
		}

	    /// <summary>
	    /// 
	    /// </summary>
	    /// <param name="tagName">The tag name</param>
	    /// <param name="htmlAttributes">A dictionary of html attributes. Values get HtmlEncoded.</param>
	    /// <param name="encoder"></param>
	    public TagBuilder(string tagName, IDictionary<string, object> htmlAttributes, HtmlEncoder encoder = null)
        {
	        this.encoder = encoder ?? HtmlEncoder.Default;
	        this.TagName = tagName;
            this.HtmlAttributes = htmlAttributes == null ? new Dictionary<string, object>() : new Dictionary<string, object>(htmlAttributes);
        }

		public void SetInnerText(string text)
		{
			// Do not remove coding without prior discussion
			this.InnerHtml = encoder.Encode(text);
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
				if (this.HtmlAttributes[key] is HtmlProperty)
				{
					builder.Append(" ").Append(key);
				}
				else
				{
					var encoded = this.HtmlEncode(this.HtmlAttributes[key]);
					if (encoded != null)
						builder.Append($" {key}=\"{encoded}\"");
				}
			}
		}

    	string HtmlEncode(object value)
		{
			if(value == null)
				return null;

			var stringValue = value.ToString();

			return this.encoder.Encode(stringValue);
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