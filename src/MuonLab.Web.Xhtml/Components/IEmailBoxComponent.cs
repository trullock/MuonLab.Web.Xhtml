namespace MuonLab.Web.Xhtml.Components
{
    public interface IEmailBoxComponent : ITextBoxComponent
    {
    }

	public interface IEmailBoxComponent<TProperty> : ITextBoxComponent<TProperty>, IEmailBoxComponent
    {
		
    }
}