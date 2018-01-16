using System.Collections.Generic;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms
{
	public interface IValidationMessageRenderer
	{
		string Render(ComponentState state, ValidationMarkerMode showValidationMessageMode, IEnumerable<string> validationErrors, string id);
	}
}