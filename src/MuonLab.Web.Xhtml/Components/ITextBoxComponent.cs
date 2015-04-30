namespace MuonLab.Web.Xhtml.Components
{
    public interface ITextBoxComponent : IFormattableComponent
    {
        ITextBoxComponent ShowDefaultAsEmpty();
        ITextBoxComponent WithPlaceholder();
        ITextBoxComponent WithPlaceholder(string placeholder);
	    ITextBoxComponent WithExplicitPlaceholder(string placeholder);
        ITextBoxComponent PreventAutoComplete();
        ITextBoxComponent AllowAutoComplete();
        ITextBoxComponent WithMaxLength(int length);
    }

    public interface ITextBoxComponent<TProperty> : IFormattableComponent<TProperty>, ITextBoxComponent
    {
		
    }
}