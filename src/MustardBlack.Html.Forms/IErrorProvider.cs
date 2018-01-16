using System.Collections.Generic;

namespace MustardBlack.Html.Forms
{
	public interface IErrorProvider
	{
		IDictionary<string, IList<string>> AllErrors { get; }
		IEnumerable<string> GetErrorsFor(string componentName);
		ComponentState GetStateFor(string componentName);
		string GetAttemptedValueFor(string componentName);
	}
}