namespace MustardBlack.Html.Components
{
	public interface ICheckBoxComponent : IVisibleComponent
	{
		
	}

	public interface ICheckBoxComponent<in TProperty> : IVisibleComponent<TProperty>, ICheckBoxComponent
	{

	}
}