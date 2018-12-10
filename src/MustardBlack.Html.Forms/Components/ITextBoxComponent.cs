namespace MustardBlack.Html.Forms.Components
{
    public interface ITextBoxComponent : IFormattableComponent
    {
        ITextBoxComponent ShowDefaultAsEmpty();
        ITextBoxComponent WithPlaceholder();
        ITextBoxComponent WithPlaceholder(string placeholder);
	    ITextBoxComponent WithExplicitPlaceholder(string placeholder);
        ITextBoxComponent AutoComplete(string value);
        ITextBoxComponent WithMaxLength(int length);
    }

    public interface ITextBoxComponent<TProperty> : IFormattableComponent<TProperty>, ITextBoxComponent
    {
		
    }
}