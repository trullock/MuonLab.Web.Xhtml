namespace MustardBlack.Html.Forms.Components
{
    public interface IEmailBoxComponent : ITextBoxComponent
    {
    }

	public interface IEmailBoxComponent<TProperty> : ITextBoxComponent<TProperty>, IEmailBoxComponent
    {
		
    }
}