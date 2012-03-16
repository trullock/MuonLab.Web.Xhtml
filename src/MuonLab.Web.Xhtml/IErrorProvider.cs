using System.Collections.Generic;
using MuonLab.Web.Xhtml.Properties;

namespace MuonLab.Web.Xhtml
{
	public interface IErrorProvider
	{
		IDictionary<string, IList<string>> AllErrors { get; }
		IEnumerable<string> GetErrorsFor(string componentName);
		ComponentState GetStateFor(string componentName);
		string GetAttemptedValueFor(string componentName);
	}
}