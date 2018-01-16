using System.Globalization;
using MustardBlack.Html.Configuration;

namespace MustardBlack.Html.Components
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
			this.AddAriaDescribedBy();

            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }
    }
}