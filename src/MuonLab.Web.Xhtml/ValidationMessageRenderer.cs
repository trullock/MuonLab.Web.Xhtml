using System.Collections.Generic;
using System.Linq;
using MuonLab.Web.Xhtml.Properties;

namespace MuonLab.Web.Xhtml
{
	public class ValidationMessageRenderer : IValidationMessageRenderer
	{
		public virtual string Render(ComponentState state, ValidationMarkerMode showValidationMessageMode, IEnumerable<string> validationErrors)
		{
			if (state == ComponentState.Unvalidated && showValidationMessageMode != ValidationMarkerMode.Always)
				return "";

			var builder = new TagBuilder("span");

			if (state == ComponentState.Invalid)
			{
				var firstError = validationErrors.FirstOrDefault();
				if (firstError != null)
				{
					builder.SetInnerText(firstError);
					builder.HtmlAttributes["class"] = "field-validation-message field-validation-error";
				}
			}
			else if (state == ComponentState.Valid)
				builder.HtmlAttributes["class"] = "field-validation-message field-validation-ok";
			else
				builder.HtmlAttributes["class"] = "field-validation-message";

			return builder.ToString();
		}

	}
}