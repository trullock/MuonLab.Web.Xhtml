namespace MuonLab.Web.Xhtml.Components
{
    public interface ITextBoxComponent : IFormattableComponent
    {
        ITextBoxComponent ShowDefaultAsEmpty();
        ITextBoxComponent PreventAutoComplete();
        ITextBoxComponent AllowAutoComplete();
        ITextBoxComponent WithMaxLength(int length);
    }

    public interface ITextBoxComponent<TProperty> : IFormattableComponent<TProperty>, ITextBoxComponent
    {
		
    }
}