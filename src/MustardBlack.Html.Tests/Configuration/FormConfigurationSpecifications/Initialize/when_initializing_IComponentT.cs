using System;
using MustardBlack.Html.Components;
using MustardBlack.Html.Configuration;
using NSubstitute;

namespace MustardBlack.Html.Tests.Configuration.FormConfigurationSpecifications.Initialize
{
    public class when_initializing_IComponentT : Specification
    {
	    TestFormConfiguration configuration;
	    IComponent<object> component;

        protected override void Given()
        {
            configuration = new TestFormConfiguration();
            component = Stub<IComponent<object>>();
        }

        protected override void When()
        {
            configuration.Initialize(component);
        }

        [Then]
        public void the_component_should_have_the_icomponent_config_ran_on_it()
        {
            component.Received().WithId("test");
        }

        [Then]
        public void the_component_should_have_the_icomponentT_config_ran_on_it()
        {
            component.Received().WithName("test");
        }

        [Then]
        public void the_component_should_not_have_the_icomponentT2_config_ran_on_it()
        {
            component.DidNotReceive().WithName("fish");
        }

        private class TestFormConfiguration : FormConfiguration
        {
            public TestFormConfiguration()
            {
                Configure<IComponent>(c => c.WithId("test"));
                Configure<IComponent<object>>(c => c.WithName("test"));
                Configure<IComponent<DateTime>>(c => c.WithName("fish"));
            }
        }
    }
}