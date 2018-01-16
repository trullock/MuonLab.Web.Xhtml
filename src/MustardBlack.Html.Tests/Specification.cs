using System;

namespace MustardBlack.Html.Tests
{
	public abstract class Specification : AutoMocker, IDisposable
	{
		Type expectedExceptionType;
		Exception thrownException;

		protected Specification()
		{
			Given();

			try
			{
				When();
			}
			catch (Exception e)
			{
			    if (e.GetType() != this.expectedExceptionType)
					throw;
			    
                this.thrownException = e;
			}
		}

		protected void Expect<TException>() where TException : Exception
		{
			this.expectedExceptionType = typeof(TException);
		}

		protected TException Thrown<TException>() where TException : Exception
		{
			return this.thrownException as TException;
		}

		protected virtual void Given() {}
		protected abstract void When();
		
		public virtual void Dispose()
		{
		}
	}
}