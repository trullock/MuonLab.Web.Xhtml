namespace MuonLab.Web.Xhtml.Components.Implementations
{
    public class FileUploadComponent<TViewModel, TProperty> : 
		VisibleComponent<TViewModel, TProperty>, 
		IFileUploadComponent
    {
        public override string ControlPrefix
        {
            get { return "fup"; }
        }

        protected override string RenderComponent()
        {
            this.htmlAttributes.Add("type", "file");

            var builder = new TagBuilder("input", this.htmlAttributes);
            return builder.ToString();
        }
    }
}