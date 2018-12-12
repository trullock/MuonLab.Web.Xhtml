namespace MustardBlack.Html.Forms.Components
{
    public interface IPasswordBoxComponent : IVisibleComponent<string>
    {
		/// <summary>
		/// https://developer.mozilla.org/en-US/docs/Web/HTML/Attributes/autocomplete#Values
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		IPasswordBoxComponent AutoComplete(string value);

		IPasswordBoxComponent WithPlaceholder();
		IPasswordBoxComponent WithPlaceholder(string placeholder);
    }
}