using System.Collections.Generic;
using System.ComponentModel;

namespace MustardBlack.Html.Forms
{
	static class ObjectToDictionaryExtension
	{
		public static IDictionary<string, object> ToDictionary(this object self)
		{
			var dictionary = new Dictionary<string, object>();
			foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(self))
			{
				var obj2 = descriptor.GetValue(self);
				dictionary.Add(descriptor.Name.Replace("_", "-"), obj2);
			}
			return dictionary;
		}
	}
}
