namespace MustardBlack.Html.Forms.Components
{
    public interface IPasswordBoxComponent : IVisibleComponent<string>
    {
        IPasswordBoxComponent PreventAutoComplete();
        IPasswordBoxComponent AllowAutoComplete();

		IPasswordBoxComponent WithPlaceholder();
		IPasswordBoxComponent WithPlaceholder(string placeholder);
    }
}