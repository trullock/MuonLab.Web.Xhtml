using System;
using System.Collections.Generic;
using System.Web;
using MuonLab.Web.Xhtml.Components;

namespace MuonLab.Web.Xhtml.Configuration
{
	public class FormConfiguration : IFormConfiguration
	{
		readonly IDictionary<Type, IList<Delegate>> configurations;

		protected FormConfiguration()
		{
			this.configurations = new Dictionary<Type, IList<Delegate>>();
		}

		protected void Configure<TComponent>(Action<TComponent> configuration) where TComponent : IComponent
		{
			var type = typeof(TComponent);

			if(!this.configurations.ContainsKey(type))
				this.configurations.Add(type, new List<Delegate>());

			this.configurations[type].Add(configuration);
		}

		protected void Unconfigure<TComponent>(Action<TComponent> configuration) where TComponent : IComponent
		{
			var type = typeof(TComponent);

			if (!this.configurations.ContainsKey(type))
				return;

			this.configurations[type].Remove(configuration);
		}

	    public void Initialize(IComponent component)
	    {
            var configs = this.GetMatchingConfigurations(component.GetType());

            foreach (var config in configs)
            {
                config.DynamicInvoke(component);
            }
	    }

		public virtual IHtmlString StartMultiField()
		{
			return new HtmlString("<div class=\"multiField\">");
		}

		public virtual IHtmlString EndMultiField()
		{
			return new HtmlString("</div>");
		}

		IEnumerable<Delegate> GetMatchingConfigurations(Type component)
		{
			var matchedConfigs = new List<Delegate>();

			foreach(var configType in this.configurations.Keys)
			{
				if(ConfigurationMatches(configType, component))
					matchedConfigs.AddRange(this.configurations[configType]);
			}

			return matchedConfigs;
		}

		static bool ConfigurationMatches(Type configType, Type componentType)
		{
			return configType.IsAssignableFrom(componentType);
		}
	}
}