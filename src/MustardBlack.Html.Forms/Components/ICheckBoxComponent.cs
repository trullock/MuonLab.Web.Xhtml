namespace MustardBlack.Html.Forms.Components
{
	public interface ICheckBoxComponent : IVisibleComponent
	{
		
	}

	public interface ICheckBoxComponent<in TProperty> : IVisibleComponent<TProperty>, ICheckBoxComponent
	{

	}
}