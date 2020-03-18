using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using MustardBlack.Html.Forms.Configuration;

namespace MustardBlack.Html.Forms.Components
{
    public abstract class VisibleComponent<TViewModel, TProperty> : 
		Component<TViewModel, TProperty>, 
		IVisibleComponent<TProperty>
    {
	    protected readonly ITermResolver termResolver;
	    protected readonly CultureInfo culture;
	    internal event EventHandler OnPrepareForRender;

	    protected IValidationMessageRenderer ValidationMessageRenderer;

    	protected ComponentState state;
        protected IEnumerable<string> validationErrors;

        protected bool showLabel;
	    protected bool ariaLabel;
	    protected bool ariaDescribedBy;

		protected bool showValidationMessage;
		protected ValidationMarkerMode showValidationMessageMode;

	    protected string wrapperStartHtml;
	    protected string wrapperEndHtml;
        protected IDictionary<string, object> wrapperHtmlAttributes;
        protected string wrapperTagName;
		
        protected string helpText;

        protected IEnumerable<ComponentPart> renderingOrder;
	    protected ContentType labelContentType;
	    protected ContentType helpTextContentType;
	    protected object labelAttributes;
	    protected object helpTextAttributes;

	    public string Label { get; protected set; }

        protected VisibleComponent(ITermResolver termResolver, IValidationMessageRenderer validationMessageRenderer, CultureInfo culture)
        {
	        this.termResolver = termResolver;
	        this.culture = culture;
	        this.validationErrors = new string[0];
			this.renderingOrder = new ComponentPart[0];
			this.showValidationMessage = true;
			this.ValidationMessageRenderer = validationMessageRenderer;
			this.labelContentType = ContentType.Term;
			this.helpTextContentType = ContentType.Term;
			this.labelAttributes = new object();
			this.helpTextAttributes = new object();
        }

		public IVisibleComponent WithValidationMessageRenderer(IValidationMessageRenderer messageRenderer)
		{
			this.ValidationMessageRenderer = messageRenderer;
			return this;
		}

        public IVisibleComponent WithState(ComponentState state, IEnumerable<string> validationErrors)
        {
        	this.state = state;
            this.validationErrors = validationErrors;
            return this;
        }

	    /// <summary>
	    /// Enables Aria accessibility helpers
	    /// </summary>
	    /// <returns></returns>
	    public IVisibleComponent WithAria(bool label = true, bool describedBy = true)
		{
			this.ariaLabel = label;
			this.ariaDescribedBy = describedBy;
			return this;
		}


        /// <summary>
        /// Adds an HTML Label tag to the markup with text automatically determined from the property represented by the component
        /// </summary>
        /// <returns></returns>
        public IVisibleComponent WithLabel()
        {
            return WithLabel(this.Label);
        }

        /// <summary>
        /// Adds an HTML Label tag to the markup with the given text.
        /// </summary>
        /// <param name="label">The label text</param>
        /// <returns></returns>
        public IVisibleComponent WithLabel(string label, ContentType contentType = ContentType.Term)
        {
            this.showLabel = true;
            this.Label = label;
	        this.labelContentType = contentType;
            return this;
        }

        public IVisibleComponent WithLabelAttributes(object attributes)
        {
	        this.labelAttributes = attributes;
	        return this;
        }

        /// <summary>
        /// Prevents an HTML label from being rendered
        /// </summary>
        /// <returns></returns>
        public IVisibleComponent WithoutLabel()
        {
            this.showLabel = false;
            return this;
        }

        /// <summary>
        /// Adds a validation message to the markup when the field is invalid
        /// </summary>
        /// <returns></returns>
		public IVisibleComponent WithValidationMessage(ValidationMarkerMode mode)
        {
            this.showValidationMessage = true;
        	this.showValidationMessageMode = mode;
            return this;
        }

        /// <summary>
        /// Prevents a validation message from being displayed
        /// </summary>
        /// <returns></returns>
        public IVisibleComponent WithoutValidationMessage()
        {
			this.showValidationMessage = false;
            return this;
        }

        /// <summary>
        /// Sets the help text for the component
        /// </summary>
        /// <returns></returns>
        public IVisibleComponent WithHelpText(string helpText, ContentType contentType = ContentType.Term)
        {
            this.helpText = helpText;
	        this.helpTextContentType = contentType;
            return this;
        }

        public IVisibleComponent WithHelpTextAttributes(object attributes)
        {
	        this.helpTextAttributes = attributes;
	        return this;
        }

        /// <summary>
        /// set teh field as readonly
        /// </summary>
        /// <returns></returns>
        public virtual IVisibleComponent ReadOnly()
        {
            this.WithAttr("readonly", "readonly");
            return this;
        }

        /// <summary>
        /// Wraps all rendered tags in an outer tag with the given name
        /// </summary>
        /// <param name="tagName">the tag name, e.g. "div". Pass null for no wrapper</param>
        /// <returns></returns>
        public IVisibleComponent WithWrapper(string tagName)
        {
            this.wrapperTagName = tagName;
            this.wrapperHtmlAttributes = null;
            return this;
        }

        /// <summary>
        /// Wraps all rendered tags in an outer tag with the given name
        /// </summary>
        /// <param name="tagName">the tag name, e.g. "div". Pass null for no wrapper</param>
        /// <param name="htmlAttributes">The html attributes to apply to the wrapper</param>
        /// <returns></returns>
        public IVisibleComponent WithWrapper(string tagName, object htmlAttributes)
        {
            this.wrapperTagName = tagName;
            this.wrapperHtmlAttributes = htmlAttributes.ToHtmlAttributeDictionary();
            return this;
        }

	    public IVisibleComponent WithWrapperStartHtml(string html)
	    {
		    this.wrapperStartHtml = html;
		    return this;
	    }

	    public IVisibleComponent WithWrapperEndHtml(string html)
	    {
		    this.wrapperEndHtml = html;
		    return this;
	    }


        /// <summary>
        /// Sets the rendering order for this parts of the component
        /// </summary>
        /// <param name="renderingOrder"></param>
        /// <returns></returns>
        public IVisibleComponent WithRenderingOrder(params ComponentPart[] renderingOrder)
        {
            this.renderingOrder = renderingOrder;
            return this;
        }

	    protected virtual void AddAriaDescribedBy()
	    {
		    if (!this.ariaDescribedBy)
			    return;

		    if (!this.htmlAttributes.ContainsKey("id"))
			    return;

			var id = this.htmlAttributes["id"];
			if (id != null)
			{
				if (this.renderingOrder.Contains(ComponentPart.HelpText))
					this.htmlAttributes["aria-describedby"] = this.htmlAttributes["id"] + "_Help";

				if (this.renderingOrder.Contains(ComponentPart.ValidationMessage) && (this.showValidationMessage && this.showValidationMessageMode == ValidationMarkerMode.Always || this.validationErrors.Any()))
				{
					if (!string.IsNullOrEmpty(this.helpText))
						this.htmlAttributes["aria-describedby"] = this.htmlAttributes["aria-describedby"] + " " +
																  this.htmlAttributes["id"] + "_Validation";
					else
						this.htmlAttributes["aria-describedby"] = this.htmlAttributes["id"] + "_Validation";
				}
			}
	    }

        protected virtual string RenderLabel()
        {
            var htmlAttribs = new Dictionary<string, object>();
            htmlAttribs.Add("for", this.GetAttr("id"));

			var labelAttribs = this.labelAttributes.ToHtmlAttributeDictionary();
			foreach(var key in labelAttribs.Keys)
				htmlAttribs.Add(key, labelAttribs[key]);

			var labelBuilder = new TagBuilder("label", htmlAttribs);
			labelBuilder.InnerHtml = this.labelContentType == ContentType.Term ? this.termResolver.ResolveTerm(this.Label, this.culture) : this.Label;
			
            return labelBuilder.ToString();
        }

        protected virtual string RenderValidationMessage()
        {
	        if (!this.showValidationMessage)
		        return null;

			var id = this.GetAttr("id");

			return this.ValidationMessageRenderer.Render(this.state, this.showValidationMessageMode, this.validationErrors, id + "_Validation");
        }

        protected virtual string RenderHelpText()
        {
	        var attributes = new Dictionary<string, object>();
			attributes.Add("class", "field-help-text");

			var spanAttribs = this.helpTextAttributes.ToHtmlAttributeDictionary();
			foreach (var key in spanAttribs.Keys)
				attributes[key] = spanAttribs[key];

			var id = this.GetAttr("id");
	        if(id != null)
				attributes.Add("id", id + "_Help");

	        var tagBuilder = new TagBuilder("span", attributes);
	        tagBuilder.InnerHtml = this.helpTextContentType == ContentType.Term ? this.termResolver.ResolveTerm(this.helpText, this.culture) : this.helpText;
	        return tagBuilder.ToString();
        }

        protected virtual string RenderWrapperEndTag()
        {
	        if (!string.IsNullOrEmpty(this.wrapperEndHtml))
		        return this.wrapperEndHtml;

            if (!string.IsNullOrEmpty(this.wrapperTagName))
                return "</" + this.wrapperTagName + ">";

            return null;
        }

        protected virtual string RenderWrapperStartTag()
        {
	        if (!string.IsNullOrEmpty(this.wrapperStartHtml))
		        return this.wrapperStartHtml;

	        if (!string.IsNullOrEmpty(this.wrapperTagName))
            {
                var builder = new TagBuilder(this.wrapperTagName, this.wrapperHtmlAttributes);
                return builder.ToString(TagRenderMode.StartTag);
            }

            return null;
        }

        protected virtual void PrepareForRender()
        {
			if(this.OnPrepareForRender != null)
				this.OnPrepareForRender(this, new EventArgs());

            if (this.state == ComponentState.Invalid)
                this.AddClass("input-validation-error");

			if (this.state == ComponentState.Valid)
				this.AddClass("input-validation-ok");
        }

        public override string ToString()
        {
            this.PrepareForRender();
			
            var builder = new StringBuilder();

            foreach (var part in renderingOrder)
            {
                switch (part)
                {
                    case ComponentPart.Label:
                        if(showLabel)
                            builder.Append(RenderLabel());
                        break;
                    case ComponentPart.Component:
                        builder.Append(RenderComponent());
                        break;
                    case ComponentPart.HelpText:
                        if(!string.IsNullOrEmpty(this.helpText))
                            builder.Append(RenderHelpText());
                        break;
                    case ComponentPart.ValidationMessage:
                        builder.Append(RenderValidationMessage());
                        break;
                    case ComponentPart.WrapperStartTag:
                        builder.Append(RenderWrapperStartTag());
                        break;
                    case ComponentPart.WrapperEndTag:
                        builder.Append(RenderWrapperEndTag());
                        break;
                }
            }
            return builder.ToString();
        }		
    }
}