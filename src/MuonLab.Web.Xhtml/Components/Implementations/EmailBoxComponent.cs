namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class EmailBoxComponent<TViewModel, TProperty> : 
		TextBoxComponent<TViewModel, TProperty>, 
		IEmailBoxComponent<TProperty> 
    {
        public override string ControlPrefix
        {
            get { return "txt"; }
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

			if (this.useLabelForPlaceholder)
				this.htmlAttributes.Add("placeholder", this.Label);
			else if (!string.IsNullOrEmpty(this.placeholder))
				this.htmlAttributes.Add("placeholder", this.placeholder);

            this.htmlAttributes.Add("type", "email");
            this.htmlAttributes.Add("value", fieldValue);
            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }

    }
}