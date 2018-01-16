using System;
using System.Globalization;
using System.Resources;

namespace MuonLab.Web.Xhtml.Example
{
	public class ResourceTermResolver : DefaultTermResolver
	{
		readonly ResourceManager resourceManager;

		public ResourceTermResolver()
		{
			this.resourceManager = new ResourceManager("MuonLab.Web.Xhtml.Example.Forms", this.GetType().Assembly);
		}

		public override string ResolveTerm(object obj, CultureInfo culture)
		{
			if (obj == null)
				return null;

			if (obj is string)
			{
				try
				{
					return this.resourceManager.GetString(obj as string);
				}
				catch
				{
				}
			} 
			else if (obj is Enum)
			{
				return this.ResolveTerm(((Enum) obj).ToTerm(), culture);
			}
			
			return base.ResolveTerm(obj, culture);
		}
	}
}