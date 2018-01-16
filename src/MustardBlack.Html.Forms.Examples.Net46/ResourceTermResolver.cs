using System;
using System.Globalization;
using System.Resources;

namespace MustardBlack.Html.Forms.Examples.Net46
{
	sealed class ResourceTermResolver : DefaultTermResolver
	{
		readonly ResourceManager resourceManager;

		public ResourceTermResolver()
		{
			this.resourceManager = new ResourceManager("MustardBlack.Html.Forms.Examples.Net46", this.GetType().Assembly);
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