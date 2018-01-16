using MustardBlack.Html.Forms.Components;
using MustardBlack.Html.Forms.Configuration;
using NSubstitute;

namespace MustardBlack.Html.Forms.Tests.ComponentFactorySpecifications
{
	public abstract class ComponentFactorySpecification : Specification
	{
		protected TestEntity entity;
		protected IComponent component;
		protected ComponentFactory<TestEntity> factory;
		protected IFormConfiguration configuration;

		protected override void Given()
		{
			Dependency<IComponentNameResolver>()
				.ResolveName<TestEntity, string>(null)
				.ReturnsForAnyArgs("thename");

			Dependency<IComponentIdResolver>()
				.ResolveId<TestEntity, string>(null, null)
				.ReturnsForAnyArgs("theid");

			Dependency<ITermResolver>()
				.ResolveTerm<TestEntity, string>(null)
				.ReturnsForAnyArgs("thelabel");

			Dependency<ITermResolver>()
				.ResolveTerm("thelabel", null)
				.ReturnsForAnyArgs("thelabel");

			this.configuration = Dependency<IFormConfiguration>();

			this.entity = new TestEntity();

			factory = Subject<ComponentFactory<TestEntity>>();
		}

		protected abstract string expectedRendering { get; }

		[Then]
		public void TheComponentShouldHaveTheConfigurationAppliedToIt()
		{
			configuration.Received().Initialize(component);
		}

		[Then]
		public void TheComponentShouldBeRenderedCorrectly()
		{
			component.ToString().ShouldEqual(expectedRendering);
		}
	}
}