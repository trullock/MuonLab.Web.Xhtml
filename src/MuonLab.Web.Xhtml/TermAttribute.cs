using System;

namespace MuonLab.Web.Xhtml
{
	[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
	public class TermAttribute : Attribute
	{
		public string Key { get; set; }

		public TermAttribute(string key)
		{
			this.Key = key;
		}
	}
}