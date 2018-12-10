namespace MustardBlack.Html.Forms.Components
{
    public interface IPasswordBoxComponent : IVisibleComponent<string>
    {
        IPasswordBoxComponent AutoComplete(string value);

		IPasswordBoxComponent WithPlaceholder();
		IPasswordBoxComponent WithPlaceholder(string placeholder);
    }
}