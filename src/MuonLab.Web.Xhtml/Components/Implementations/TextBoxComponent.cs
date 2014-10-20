using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class TextBoxComponent<TViewModel, TProperty> : 
		FormattableComponent<TViewModel, TProperty>, 
		ITextBoxComponent<TProperty>
    {
	    protected bool useLabelForPlaceholder;
	    protected string placeholder;

	    public TextBoxComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    public override string ControlPrefix
        {
            get { return "txt"; }
        }

        protected bool asDefaultEmpty;

        public virtual ITextBoxComponent ShowDefaultAsEmpty()
        {
            this.asDefaultEmpty = true;
            return this;
        }

	    public ITextBoxComponent WithPlaceholder()
	    {
		    this.useLabelForPlaceholder = true;
		    return this;
	    }

	    public ITextBoxComponent WithPlaceholder(string text)
	    {
		    this.useLabelForPlaceholder = false;
		    this.placeholder = text;
			return this;
	    }

	    public virtual ITextBoxComponent PreventAutoComplete()
        {
            WithAttr("autocomplete", "off");
            return this;
        }

        public ITextBoxComponent AllowAutoComplete()
        {
            WithoutAttr("autocomplete");
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

            if (this.asDefaultEmpty && Equals(this.value, default(TProperty)))
                fieldValue = null;
            else
                fieldValue = this.FormatValue(this.value);

            if (this.attemptedValue != null)
                fieldValue = this.attemptedValue;
			
			if(this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if(!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

            this.htmlAttributes.Add("type", "text");
            this.htmlAttributes.Add("value", fieldValue);
            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }

    }
}