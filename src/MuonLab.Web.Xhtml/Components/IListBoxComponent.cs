namespace MuonLab.Web.Xhtml.Components
{
    public interface IListBoxComponent : IVisibleComponent
    {
	    /// <summary>
	    /// Sets the size of the list box (in rows)
	    /// </summary>
	    /// <returns></returns>
	    IListBoxComponent WithSize(int size);
    }

    public interface IListBoxComponent<in TProperty> : IListBoxComponent
	{

    }
}