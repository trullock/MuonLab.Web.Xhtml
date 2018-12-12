namespace MustardBlack.Html.Forms.Components
{
    public interface ITextBoxComponent : IFormattableComponent
    {
        ITextBoxComponent ShowDefaultAsEmpty();
        ITextBoxComponent WithPlaceholder();
        ITextBoxComponent WithPlaceholder(string placeholder);
	    ITextBoxComponent WithExplicitPlaceholder(string placeholder);

		/// <summary>
		/// https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete#Values
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		ITextBoxComponent WithAutoComplete(string value);

        ITextBoxComponent WithMaxLength(int length);
    }

    public interface ITextBoxComponent<TProperty> : IFormattableComponent<TProperty>, ITextBoxComponent
    {
		
    }
}