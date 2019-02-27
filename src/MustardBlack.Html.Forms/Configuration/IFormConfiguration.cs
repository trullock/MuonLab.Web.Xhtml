using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Configuration
{
	public interface IFormConfiguration
	{
		ITermResolver TermResolver { get; }
	    void Initialize(IComponent component);
		MultifieldTag StartMultiField();
		MultifieldTag EndMultiField();
	}
}