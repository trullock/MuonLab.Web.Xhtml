namespace MustardBlack.Html.Forms.Components
{
    public interface INumberBoxComponent : IVisibleComponent
    {
        INumberBoxComponent WithMinimum(decimal min);
        INumberBoxComponent WithMaximum(decimal max);
        INumberBoxComponent WithStep(decimal step);

        INumberBoxComponent WithPlaceholder();
        INumberBoxComponent WithPlaceholder(string placeholder);
    }
    
    public interface INumberBoxComponent<TProperty> : IVisibleComponent, INumberBoxComponent
    {

    }
}