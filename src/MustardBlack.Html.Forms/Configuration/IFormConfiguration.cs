using MustardBlack.Html.Forms.Components;

namespace MustardBlack.Html.Forms.Configuration
{
	public interface IFormConfiguration
	{
	    void Initialize(IComponent component);
		MultifieldTag StartMultiField();
		MultifieldTag EndMultiField();
	}
}