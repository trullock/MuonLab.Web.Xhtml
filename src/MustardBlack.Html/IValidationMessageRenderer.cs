using System.Collections.Generic;
using MustardBlack.Html.Configuration;

namespace MustardBlack.Html
{
	public interface IValidationMessageRenderer
	{
		string Render(ComponentState state, ValidationMarkerMode showValidationMessageMode, IEnumerable<string> validationErrors, string id);
	}
}