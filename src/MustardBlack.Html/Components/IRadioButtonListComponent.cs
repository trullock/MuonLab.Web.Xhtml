namespace MustardBlack.Html.Components
{
	public interface IRadioButtonListComponent : IVisibleComponent
	{
	}

	public interface IRadioButtonListComponent<in TProperty> : IVisibleComponent<TProperty>, IRadioButtonListComponent
    {
    }
}