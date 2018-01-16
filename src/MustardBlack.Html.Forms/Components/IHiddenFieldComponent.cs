namespace MustardBlack.Html.Forms.Components
{
    public interface IHiddenFieldComponent : IComponent
    {
		
    }

	public interface IHiddenFieldComponent<in TProperty> : IComponent<TProperty>, IHiddenFieldComponent
    {

    }
}