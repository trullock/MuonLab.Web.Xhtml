namespace MustardBlack.Html.Forms.Components
{
	public interface ITextAreaComponent : IFormattableComponent
    {
        ITextAreaComponent WithRows(int rows);
		ITextAreaComponent WithCols(int cols);
		ITextAreaComponent WithPlaceholder();
		ITextAreaComponent WithPlaceholder(string placeholder);
    }

	public interface ITextAreaComponent<TProperty> : IFormattableComponent<TProperty>, ITextAreaComponent
    {

    }
}