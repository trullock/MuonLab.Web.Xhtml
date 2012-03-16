using System.Collections.Generic;
using System.Linq;
using MuonLab.Web.Xhtml.Properties;

namespace MuonLab.Web.Xhtml
{
	public sealed class ValidationMessage
	{
		readonly ComponentState state;
		readonly ValidationMarkerMode showValidationMessageMode;
		readonly IEnumerable<string> validationErrors;

		public ValidationMessage(ComponentState state, ValidationMarkerMode showValidationMessageMode, IEnumerable<string> validationErrors)
		{
			this.state = state;
			this.validationErrors = validationErrors;
			this.showValidationMessageMode = showValidationMessageMode;
		}

		public override string ToString()
		{
			if (this.state == ComponentState.Unvalidated && showValidationMessageMode != ValidationMarkerMode.Always)
				return "";

			var builder = new TagBuilder("span");

			if (this.state == ComponentState.Invalid)
			{
				var firstError = this.validationErrors.FirstOrDefault();
				if (firstError != null)
				{
					builder.SetInnerText(firstError);
					builder.HtmlAttributes["class"] = "field-validation-message field-validation-error";
				}
			}
			else if (this.state == ComponentState.Valid)
				builder.HtmlAttributes["class"] = "field-validation-message field-validation-ok";
			else
				builder.HtmlAttributes["class"] = "field-validation-message";

			return builder.ToString();
		}
	}
}