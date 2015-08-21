using System.Globalization;
using MuonLab.Web.Xhtml.Configuration;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class PasswordBoxComponent<TViewModel> : 
		VisibleComponent<TViewModel, string>, 
		IPasswordBoxComponent
    {
		protected bool useLabelForPlaceholder;
		protected string placeholder;

	    public PasswordBoxComponent(ITermResolver termResolver, CultureInfo culture) : base(termResolver, culture)
	    {
	    }

	    public override string ControlPrefix
        {
            get { return "txt"; }
        }

        public IPasswordBoxComponent PreventAutoComplete()
        {
            WithAttr("autocomplete", "off");
            return this;
        }

        public IPasswordBoxComponent AllowAutoComplete()
        {
            WithoutAttr("autocomplete");
            return this;
        }


		public IPasswordBoxComponent WithPlaceholder()
		{
			this.useLabelForPlaceholder = true;
			return this;
		}

		public IPasswordBoxComponent WithPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.placeholder = text;
			return this;
		}

        protected override string RenderComponent()
        {
            this.htmlAttributes.Add("value", this.value);
			this.htmlAttributes.Add("type", "password");

			if (this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if (!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

			this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture));

			this.AddAriaDescribedBy();

            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }
    }
}