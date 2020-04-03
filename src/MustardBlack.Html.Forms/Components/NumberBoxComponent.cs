using System.Globalization;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
    public class NumberBoxComponent<TViewModel, TProperty> : 
		VisibleComponent<TViewModel, TProperty>, 
		INumberBoxComponent<TProperty>
    {
		protected bool useLabelForPlaceholder;
		protected string placeholder;
        protected decimal? min;
        protected decimal? max;
        protected decimal? step;

	    public override string ControlPrefix => "txt";

	    public NumberBoxComponent(ITermResolver termResolver, IValidationMessageRenderer validationMessageRenderer, CultureInfo culture) : base(termResolver, validationMessageRenderer, culture)
	    {
	    }

        public INumberBoxComponent WithMinimum(decimal min)
        {
            this.min = min;
            return this;
        }

        public INumberBoxComponent WithMaximum(decimal max)
        {
            this.max = max;
            return this;
        }

        public INumberBoxComponent WithStep(decimal step)
        {
            this.step = step;
            return this;
        }

        public INumberBoxComponent WithPlaceholder()
		{
			this.useLabelForPlaceholder = true;
			return this;
		}

		public INumberBoxComponent WithPlaceholder(string text)
		{
			this.useLabelForPlaceholder = false;
			this.placeholder = text;
			return this;
		}

        protected override string RenderComponent()
        {
            this.htmlAttributes.Add("value", this.value);
			this.htmlAttributes.Add("type", "number");

			if (this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.Label, this.culture));
			else if (!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.termResolver.ResolveTerm(this.placeholder, this.culture));

	        if (this.ariaLabel)
				this.htmlAttributes.Add("aria-label", this.termResolver.ResolveTerm(string.IsNullOrEmpty(this.Label) ? this.placeholder : this.Label, this.culture));

            if(this.min.HasValue)
                this.htmlAttributes.Add("min", min);
            if(this.max.HasValue)
                this.htmlAttributes.Add("max", max);
            if(this.step.HasValue)
                this.htmlAttributes.Add("step", step);

			this.AddAriaDescribedBy();

            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }
    }
}