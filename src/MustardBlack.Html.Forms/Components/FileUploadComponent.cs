using System.Globalization;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
    public class FileUploadComponent<TViewModel, TProperty> : 
		VisibleComponent<TViewModel, TProperty>, 
		IFileUploadComponent
    {
		protected bool withHelperSpan;

		public FileUploadComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    public override string ControlPrefix => "fup";

		public IFileUploadComponent WithHelperSpan()
		{
			this.withHelperSpan = true;
			return this;
		}
		public IFileUploadComponent WithoutHelperSpan()
		{
			this.withHelperSpan = false;
			return this;
		}

		protected override string RenderComponent()
        {
            this.htmlAttributes.Add("type", "file");
			this.AddAriaDescribedBy();

            var inputBuilder = new TagBuilder("input", this.htmlAttributes);

			if (this.withHelperSpan)
			{
				var helperBuilder = new TagBuilder("span", new { @class = "field-helper" });
				return inputBuilder.ToString() + helperBuilder;
			}

			return inputBuilder.ToString();
        }
    }
}