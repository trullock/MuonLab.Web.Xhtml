using System;
using System.Runtime.Serialization;

namespace MuonLab.Web.Xhtml
{
	public class ComponentRenderingException : Exception
	{
		public ComponentRenderingException()
		{
		}

		public ComponentRenderingException(string message) : base(message)
		{
		}

		public ComponentRenderingException(string message, Exception innerException) : base(message, innerException)
		{
		}

		protected ComponentRenderingException(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}