using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class FileUploadComponent<TViewModel, TProperty> : 
		VisibleComponent<TViewModel, TProperty>, 
		IFileUploadComponent
    {
	    public FileUploadComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    public override string ControlPrefix
        {
            get { return "fup"; }
        }

        protected override string RenderComponent()
        {
            this.htmlAttributes.Add("type", "file");

            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }
    }
}