using MuonLab.Testing;
using MuonLab.Web.Xhtml.Components;
using MuonLab.Web.Xhtml.Configuration;
using NSubstitute;

namespace MuonLab.Web.Xhtml.Tests.ComponentFactorySpecifications
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
		public void the_component_should_have_the_configuration_applied_to_it()
		{
			configuration.Received().Initialize(component);
		}

		[Then]
		public void the_component_should_be_rendered_correctly()
		{
			component.ToString().ShouldEqual(expectedRendering);
		}
	}
}