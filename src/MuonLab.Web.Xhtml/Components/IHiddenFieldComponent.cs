namespace MuonLab.Web.Xhtml.Components
{
    public interface IHiddenFieldComponent : IComponent
    {
		
    }

    public interface IHiddenFieldComponent<in TProperty> : IComponent<TProperty>, IHiddenFieldComponent
    {

    }
}