namespace MustardBlack.Html.Forms.Components
{
    public interface IFileUploadComponent : IVisibleComponent
	{
		ITextBoxComponent WithPlaceholder();
		ITextBoxComponent WithPlaceholder(string placeholder);
		ITextBoxComponent WithExplicitPlaceholder(string placeholder);
		IFileUploadComponent WithHelperSpan();
    }
}