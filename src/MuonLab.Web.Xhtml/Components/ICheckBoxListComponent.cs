namespace MuonLab.Web.Xhtml.Components
{
	public interface ICheckBoxListComponent : IVisibleComponent
	{
		ICheckBoxListComponent WithTickAll();
		ICheckBoxListComponent WithTickAll(string label);
	}

	public interface ICheckBoxListComponent<in TProperty> : IVisibleComponent<TProperty>, ICheckBoxListComponent
    {
		
    }
}