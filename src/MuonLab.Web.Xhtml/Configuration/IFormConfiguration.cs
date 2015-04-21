using System.Web;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Configuration
{
	public interface IFormConfiguration
	{
	    void Initialize(IComponent component);
		IHtmlString StartMultiField();
		IHtmlString EndMultiField();
	}
}