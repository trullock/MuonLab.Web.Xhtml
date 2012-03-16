using System;

namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public abstract class FormattableComponent<TViewModel, TProperty> : 
		VisibleComponent<TViewModel, TProperty>, 
		IFormattableComponent<TProperty> 
    {
        protected enum FormatMode
        {
            String,
            Func
        }

        protected string format;
        protected FormatMode mode;
        protected Func<TProperty, string> formatFunction;

        protected FormattableComponent()
        {
            this.format = "{0}";
            this.mode = FormatMode.String;
        }

        public virtual IFormattableComponent FormattedAs(string formatString)
        {
            this.mode = FormatMode.String;
            this.format = string.Concat("{0:", formatString, "}");
            return this;
        }

        public virtual IFormattableComponent<TProperty> FormatWith(Func<TProperty, string> formatFunc)
        {
            this.mode = FormatMode.Func;
            this.formatFunction = formatFunc;
            return this;
        }

        protected string FormatValue(TProperty value)
        {
            if (this.mode == FormatMode.Func)
                return this.formatFunction.Invoke(this.value);
		    
            if(ReferenceEquals(this.value, null))
                return null;

            return string.Format(this.format, this.value);
        }
    }
}