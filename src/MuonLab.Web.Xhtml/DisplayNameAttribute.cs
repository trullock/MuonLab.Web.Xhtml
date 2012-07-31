using System;

namespace MuonLab.Web.Xhtml
{
	[AttributeUsage(AttributeTargets.Field, AllowMultiple = false)]
	public sealed class DisplayNameAttribute : Attribute
	{
		public readonly string Name;

		public DisplayNameAttribute(string name)
		{
			this.Name = name;
		}
	}
}