using System.Globalization;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
    public class FileUploadComponent<TViewModel, TProperty> : 
		VisibleComponent<TViewModel, TProperty>, 
		IFileUploadComponent
	{
		protected bool useLabelForPlaceholder;
		protected string placeholder;
		protected bool explicitPlaceholder;
		protected bool withHelperSpan;

		public FileUploadComponent(ITermResolver termResolver, IValidationMessageRenderer validationMessageRenderer, CultureInfo culture) : base(termResolver, validationMessageRenderer, culture)
	    {
	    }

	    public override string ControlPrefix => "fup";

		public IFileUploadComponent WithExplicitPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.explicitPlaceholder = true;
			this.placeholder = text;
			return this;
		}

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

		public IFileUploadComponent WithPlaceholder()
		{
			this.useLabelForPlaceholder = true;
			this.explicitPlaceholder = false;
			return this;
		}

		public IFileUploadComponent WithPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.explicitPlaceholder = false;
			this.placeholder = text;
			return this;
		}

		protected override string RenderComponent()
        {
            this.htmlAttributes.Add("type", "file");
			
			if (this.ariaLabel)
			{
				var ariaLabel = this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture);
				if (!string.IsNullOrEmpty(ariaLabel))
					this.htmlAttributes.Add("aria-label", ariaLabel);
			}

			this.AddAriaDescribedBy();

			var inputBuilder = new TagBuilder("input", this.htmlAttributes);

			if (this.withHelperSpan)
			{
				var helperBuilder = new TagBuilder("span", new { @class = "field-helper" });

				if (this.explicitPlaceholder)
					helperBuilder.SetInnerText(this.placeholder);
				else if (this.useLabelForPlaceholder)
					helperBuilder.SetInnerText(this.termResolver.ResolveTerm(this.Label, this.culture));
				else if (!string.IsNullOrEmpty(this.placeholder))
					helperBuilder.SetInnerText(this.termResolver.ResolveTerm(this.placeholder, this.culture));
				
				return inputBuilder.ToString() + helperBuilder;
			}

			return inputBuilder.ToString();
        }
    }
}