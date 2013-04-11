namespace MuonLab.Web.Xhtml.Components
{
	public interface ICheckBoxComponent : IVisibleComponent
	{
		
	}

	public interface ICheckBoxComponent<in TProperty> : IVisibleComponent<TProperty>, ICheckBoxComponent
	{

	}
}