namespace MustardBlack.Html.Forms.Components
{
    public interface IFileUploadComponent : IVisibleComponent
	{
		IFileUploadComponent WithPlaceholder();
		IFileUploadComponent WithPlaceholder(string placeholder);
		IFileUploadComponent WithExplicitPlaceholder(string placeholder);
		IFileUploadComponent WithHelperSpan();
    }
}