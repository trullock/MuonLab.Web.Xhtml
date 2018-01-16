using MustardBlack.Html.Components;

namespace MustardBlack.Html.Configuration
{
	public interface IFormConfiguration
	{
	    void Initialize(IComponent component);
		MultifieldTag StartMultiField();
		MultifieldTag EndMultiField();
	}
}