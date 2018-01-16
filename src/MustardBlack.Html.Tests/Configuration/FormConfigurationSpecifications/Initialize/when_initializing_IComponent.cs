using MustardBlack.Html.Components;
using MustardBlack.Html.Configuration;
using NSubstitute;

namespace MustardBlack.Html.Tests.Configuration.FormConfigurationSpecifications.Initialize
{
    public class when_initializing_IComponent : Specification
    {
        TestFormConfiguration configuration;
        IComponent component;

        protected override void Given()
        {
            configuration = new TestFormConfiguration();
            component = Stub<IComponent>();
        }

        protected override void When()
        {
            configuration.Initialize(component);
        }

        [Then]
        public void the_component_should_have_the_config_ran_on_it()
        {
	        component.Received().WithId("test");
        }

        private class TestFormConfiguration : FormConfiguration
        {
            public TestFormConfiguration()
            {
                Configure<IComponent>(c => c.WithId("test"));
            }
        }
    }
}