using System.Globalization;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
    public class TextBoxComponent<TViewModel, TProperty> : 
		FormattableComponent<TViewModel, TProperty>, 
		ITextBoxComponent<TProperty>
    {
	    protected bool useLabelForPlaceholder;
	    protected string placeholder;
	    protected bool explicitPlaceholder;

	    public override string ControlPrefix => "txt";

	    public TextBoxComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    protected bool defaultAsEmpty;

        public virtual ITextBoxComponent ShowDefaultAsEmpty()
        {
            this.defaultAsEmpty = true;
            return this;
        }

	    public ITextBoxComponent WithPlaceholder()
	    {
			this.useLabelForPlaceholder = true;
			this.explicitPlaceholder = false;
		    return this;
	    }

	    public ITextBoxComponent WithPlaceholder(string text)
	    {
			this.useLabelForPlaceholder = false;
			this.explicitPlaceholder = false;
		    this.placeholder = text;
			return this;
	    }

	    public ITextBoxComponent WithExplicitPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.explicitPlaceholder = true;
			this.placeholder = text;
			return this;
	    }
		
        public ITextBoxComponent AutoComplete(string value)
        {
            WithAttr("autocomplete", value);
            return this;
        }

	    public ITextBoxComponent WithMaxLength(int length)
	    {
		    this.WithAttr("maxlength", length.ToString());
		    return this;
	    }

		protected override string RenderComponent()
        {
            string fieldValue;

            if (this.defaultAsEmpty && Equals(this.value, default(TProperty)))
                fieldValue = null;
            else
                fieldValue = this.FormatValue(this.value);

            if (this.attemptedValue != null)
                fieldValue = this.attemptedValue;

		    if (this.explicitPlaceholder)
			    this.htmlAttributes.Add("placeholder", this.placeholder);
			else if(this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if(!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

	        if (this.ariaLabel)
	        {
				var ariaLabel = this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture);
				if(!string.IsNullOrEmpty(ariaLabel))
					this.htmlAttributes.Add("aria-label", ariaLabel);
	        }

			this.AddAriaDescribedBy();

			this.htmlAttributes.Add("type", "text");
            this.htmlAttributes.Add("value", fieldValue);
            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }

    }
}