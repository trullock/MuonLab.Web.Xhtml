using System;
using MustardBlack.Html.Components;

namespace MustardBlack.Html.Tests.Components.ComponentSpecifications
{
	public abstract class HiddenComponentSpecification<TComponent> : Specification where TComponent : IComponent
	{
        protected TComponent component;

		protected override void Given()
		{
			this.component = (TComponent)Activator.CreateInstance(typeof(TComponent));
		}

		protected abstract string expectedRendering { get; }
	}
}